    using System;
    using System.Runtime.InteropServices;
    
    public static class Math {
        public static double Log1p(double arg) {
            if (arg < -1.0) throw new ArgumentException();
            return log1p(arg);
        }
    
        [DllImport("msvcr120_clr0400.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double log1p(double arg);
    }
