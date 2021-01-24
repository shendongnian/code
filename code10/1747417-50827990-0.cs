    using System;
    using System.Runtime.CompilerServices;
    class X
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        static int F0(in int x) { return x + 1; }
        [MethodImpl(MethodImplOptions.NoInlining)]
        static int F1(int x) { return x + 1; }
        public static void Main()
        {
            int x = 33;
            F0(x);
            F0(x);
            F1(x);
            F1(x);
        }
    }
