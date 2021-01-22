        [DllImport("libQuadProg.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double solveQP(
            int n, int mE, int mI,
            double[] p_G,
            // etc...
        }
