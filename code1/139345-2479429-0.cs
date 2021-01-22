    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    
    class Program {
        [DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern int _snwprintf(StringBuilder str, int length, String format, __arglist);
    
        static void Main(string[] args) {
            Double d = 1.0f;
            Int32 i = 1;
            String s = "nobugz";
            StringBuilder str = new StringBuilder(666);
    
            _snwprintf(str, str.Capacity, "%10.1lf %d %s", __arglist(d, i, s));
            Console.WriteLine(str.ToString());
            Console.ReadKey();
        }
    }
