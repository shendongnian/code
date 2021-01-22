    using System.Runtime.InteropServices;
    
    namespace Sample
    {
        class Program
        {
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int printf(string format, __arglist);
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int scanf(string format, __arglist);
    
            static void Main()
            {
                int a, b;
                scanf("%d%d", __arglist(out a, out b));
                printf("The sum of %d and %d is %d.\n", __arglist(a, b, a + b));
            }
        }
    }
