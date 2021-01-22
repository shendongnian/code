    using System.Runtime.InteropServices;
    
    namespace Sample
    {
        class Program
        {
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int printf(string format, int a, int b, int c);
    
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int scanf(string format, out int a, out int b);
    
            static void Main()
            {
                int a, b;
                scanf("%d%d", out a, out b);
                printf("The sum of %d and %d is %d.\n", a, b, a + b);
            }
        }
    }
