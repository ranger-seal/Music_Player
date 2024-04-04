using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music_HKTK
{
    class Program
    {
        public enum Scale
        {
            Rest = 0, C8 = 108, B7 = 107, A7s = 106, A7 = 105, G7s = 104, G7 = 103, F7s = 102, F7 = 101, E7 = 100,
            D7s = 99, D7 = 98, C7s = 97, C7 = 96, B6 = 95, A6s = 94, A6 = 93, G6s = 92, G6 = 91, F6s = 90, F6 = 89,
            E6 = 88, D6s = 87, D6 = 86, C6s = 85, C6 = 84, B5 = 83, A5s = 82, A5 = 81, G5s = 80, G5 = 79, F5s = 78,
            F5 = 77, E5 = 76, D5s = 75, D5 = 74, C5s = 73, C5 = 72, B4 = 71, A4s = 70, A4 = 69, G4s = 68, G4 = 67,
            F4s = 66, F4 = 65, E4 = 64, D4s = 63, D4 = 62, C4s = 61, C4 = 60, B3 = 59, A3s = 58, A3 = 57, G3s = 56,
            G3 = 55, F3s = 54, F3 = 53, E3 = 52, D3s = 51, D3 = 50, C3s = 49, C3 = 48, B2 = 47, A2s = 46, A2 = 45,
            G2s = 44, G2 = 43, F2s = 42, F2 = 41, E2 = 40, D2s = 39, D2 = 38, C2s = 37, C2 = 36, B1 = 35, A1s = 34,
            A1 = 33, G1s = 32, G1 = 31, F1s = 30, F1 = 29, E1 = 28, D1s = 27, D1 = 26, C1s = 25, C1 = 24, B0 = 23,
            A0s = 22, A0 = 21
        }

        public enum Voice
        {
            X1 = Scale.C2, X2 = Scale.D2, X3 = Scale.E2, X4 = Scale.F2, X5 = Scale.G2, X6 = Scale.A2, X7 = Scale.B2,
            L1 = Scale.C3, L2 = Scale.D3, L3 = Scale.E3, L4 = Scale.F3, L5 = Scale.G3, L6 = Scale.A3, L7 = Scale.B3,
            M1 = Scale.C4, M2 = Scale.D4, M3 = Scale.E4, M4 = Scale.F4, M5 = Scale.G4, M6 = Scale.A4, M7 = Scale.B4,
            H1 = Scale.C5, H2 = Scale.D5, H3 = Scale.E5, H4 = Scale.F5, H5 = Scale.G5, H6 = Scale.A5, H7 = Scale.B5,
            LOW_SPEED = 500, MIDDLE_SPEED = 400, HIGH_SPEED = 300,
            _ = 0xFF
        }

        [DllImport("winmm.dll")]
        private static extern int midiOutOpen(out int handle, int deviceID, IntPtr callback, IntPtr instance, int flags);

        [DllImport("winmm.dll")]
        private static extern int midiOutShortMsg(int handle, int message);

        [DllImport("winmm.dll")]
        private static extern int midiOutClose(int handle);

        /// <summary>
        /// 海阔天空
        /// </summary>
        static void HKTK()
        {
            int handle;
            midiOutOpen(out handle, 0, IntPtr.Zero, IntPtr.Zero, 0);

            int volume = 0x7f;
            int voice = 0x0;
            int sleep = 400;
            int tmp = 0;

            int[] hktk =
            {(int)Voice.X4, (int)Voice.H7 - 1, (int)Voice._, (int)Voice.H6, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice.H5, (int)Voice.H4, (int)Voice.H3, (int)Voice.H2, (int)Voice._, (int)Voice.L7 - 1, (int)Voice.M1, (int)Voice.M4, (int)Voice.X7 - 1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice.L7 - 1, (int)Voice.M1, (int)Voice.M4, (int)Voice.X7 - 1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice.L7 - 1, (int)Voice.M1, (int)Voice.M5, (int)Voice.M4, (int)Voice._, (int)Voice._, (int)Voice._,
            1000, (int)Voice.M3, 0, (int)Voice.M2, 700, 300, (int)Voice.M1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, 0, (int)Voice.M3, (int)Voice.M4, 300, (int)Voice.M5, 0, (int)Voice.M5, (int)Voice.M5, 300, (int)Voice._, (int)Voice.M6, 700, (int)Voice.M5, (int)Voice._, (int)Voice._, (int)Voice._,
            0, (int)Voice.M6, (int)Voice.M7, 300, (int)Voice.H1, 0, (int)Voice.H1, 300, (int)Voice.H1, 700, (int)Voice.H1, (int)Voice.H1, (int)Voice.M7, 0, (int)Voice.M6, 300, (int)Voice.M5, 700, 0, (int)Voice.M6, 300, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice.M6, (int)Voice.M5, (int)Voice.M5, (int)Voice._, (int)Voice._, (int)Voice.M5, (int)Voice.M3, (int)Voice._, (int)Voice.M3, (int)Voice.M4, (int)Voice.M3, (int)Voice.M2, (int)Voice.M2, 0, (int)Voice.M3, (int)Voice.M2, 300, (int)Voice._, (int)Voice._, (int)Voice.M3, 0, (int)Voice.M2, (int)Voice.M2, (int)Voice._, 300, (int)Voice.M1, (int)Voice.M1, 0, (int)Voice.M1, (int)Voice.M1, 300, (int)Voice._, (int)Voice._, (int)Voice.M2, (int)Voice.M1, (int)Voice.M1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._,
            1000, (int)Voice.M3, 0, (int)Voice.M2, 700, 300, (int)Voice.M1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, 0, (int)Voice.M3, (int)Voice.M4, 300, (int)Voice.M5, 0, (int)Voice.M5, (int)Voice.M5, 300, (int)Voice._, (int)Voice.M6, 700, (int)Voice.M5, (int)Voice._, (int)Voice._, (int)Voice._,
            0, (int)Voice.M6, (int)Voice.M7, 300, (int)Voice.H1, 0, (int)Voice.H1, 300, (int)Voice.H1, 700, (int)Voice.H1, (int)Voice.H1, (int)Voice.M7, 0, (int)Voice.M6, 300, (int)Voice.M5, 700, 0, (int)Voice.M6, 300, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice.M6, (int)Voice.M5, (int)Voice.M5, (int)Voice._, (int)Voice._, (int)Voice.M5, (int)Voice.M3, (int)Voice._, (int)Voice.M3, (int)Voice.M4, (int)Voice.M3, (int)Voice.M2, (int)Voice.M2, 0, (int)Voice.M3, (int)Voice.M2, 300, (int)Voice._, (int)Voice._, (int)Voice.M3, 0, (int)Voice.M2, (int)Voice.M2, (int)Voice._, 300, (int)Voice.M1, (int)Voice.M1, 0, (int)Voice.M1, (int)Voice.M1, 300, (int)Voice._, (int)Voice._, (int)Voice.M2, (int)Voice.M1, (int)Voice.M1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice._, 0, (int)Voice.M6, (int)Voice.M7, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H1, (int)Voice._, 300, (int)Voice.H1, (int)Voice.M7, (int)Voice.M6, 0, (int)Voice.M5, 300, (int)Voice.M5, 700, (int)Voice.M5, (int)Voice._, 0, (int)Voice.M3, 300, (int)Voice.M2, 700, (int)Voice.M1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H2, (int)Voice._, 300, (int)Voice.H2, 0, (int)Voice.H1, 300, (int)Voice.H2, 700, (int)Voice.H3, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice.H3, 0, (int)Voice.H2, 300, (int)Voice.H1, 700,
            (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H2, 300, (int)Voice._, (int)Voice._, (int)Voice._, 0, (int)Voice.M5, (int)Voice.M5, 300, (int)Voice.H3, (int)Voice._, (int)Voice.H2, (int)Voice._, (int)Voice.H1, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H2, 300, (int)Voice._, 0, (int)Voice.H2, (int)Voice.H2, (int)Voice.H1, 300, (int)Voice.M7, 700, (int)Voice.H1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice.M6, (int)Voice.M6, (int)Voice.M7, (int)Voice.M6, (int)Voice.M7, (int)Voice.H1, (int)Voice._, (int)Voice._, (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H2, (int)Voice.H1, (int)Voice.H2, (int)Voice.H3, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice.H3, (int)Voice.H2, (int)Voice._, (int)Voice._, 0, (int)Voice.H2, (int)Voice.H3, 300, (int)Voice.H1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice._, 0, (int)Voice.M6, (int)Voice.M7, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H1, (int)Voice._, 300, (int)Voice.H1, (int)Voice.M7, (int)Voice.M6, 0, (int)Voice.M5, 300, (int)Voice.M5, 700, (int)Voice.M5, (int)Voice._, 0, (int)Voice.M3, 300, (int)Voice.M2, 700, (int)Voice.M1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H2, (int)Voice._, 300, (int)Voice.H2, 0, (int)Voice.H1, 300, (int)Voice.H2, 700, (int)Voice.H3, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice.H3, 0, (int)Voice.H2, 300, (int)Voice.H1, 700,
            (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H2, 300, (int)Voice._, (int)Voice._, (int)Voice._, 0, (int)Voice.M5, (int)Voice.M5, 300, (int)Voice.H3, (int)Voice._, (int)Voice.H2, (int)Voice._, (int)Voice.H1, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H2, 300, (int)Voice._, 0, (int)Voice.H2, (int)Voice.H2, (int)Voice.H1, 300, (int)Voice.M7, 700, (int)Voice.H1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H2, 300, (int)Voice._, (int)Voice._, (int)Voice._, 0, (int)Voice.M5, (int)Voice.M5, 300, (int)Voice.H3, (int)Voice._, (int)Voice.H2, (int)Voice._, (int)Voice.H1, (int)Voice._, (int)Voice._, (int)Voice._,
            (int)Voice._, 0, (int)Voice.H1, (int)Voice.H1, 300, (int)Voice.H1, 0, (int)Voice.H1, (int)Voice.H2, 300, (int)Voice._, 0, (int)Voice.H2, (int)Voice.H2, (int)Voice.H1, 300, (int)Voice.M7, 700, (int)Voice.H1, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._, (int)Voice._,
            };

            foreach (var i in hktk)
            {
                if (i == (int)Voice.LOW_SPEED || i == (int)Voice.HIGH_SPEED || i == (int)Voice.MIDDLE_SPEED)
                {
                    sleep = i;
                    continue;
                }
                if (i == 0)
                {
                    sleep = 200;
                    continue;
                }
                if (i == 700)
                {
                    Thread.Sleep(200);
                    continue;
                }
                if (i == 0xFF)
                {
                    Thread.Sleep(400);
                    continue;
                }

                if (i == 1000)
                {
                    tmp = +5;
                    continue;
                }

                voice = (volume << 16) + ((i + tmp) << 8) + 0x90;
                midiOutShortMsg(handle, voice);
                Console.WriteLine(voice);
                Thread.Sleep(sleep);
            }
            midiOutClose(handle);
        }

        static void Main(string[] args)
        {
            HKTK();
        }
    }
}
