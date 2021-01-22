    class Program
    {
        [DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern int _snwprintf_s([MarshalAs(UnmanagedType.LPWStr)] StringBuilder str, IntPtr bufferSize, IntPtr length, String format, int p);
        [DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern int _snwprintf_s([MarshalAs(UnmanagedType.LPWStr)] StringBuilder str, IntPtr bufferSize, IntPtr length, String format, double p);
        static void Main(string[] args)
        {
            // Preallocate this to a given length
            StringBuilder str = new StringBuilder(100);
            double d = 1.4;
            int i = 7;
            float s = 1.1f;
            // No need for box/unbox
            _snwprintf_s(str, (IntPtr)100, (IntPtr)32, "%10.1lf", d);
            Console.WriteLine(str.ToString());
            _snwprintf_s(str, (IntPtr)100, (IntPtr)32, "%10.1f", s);
            Console.WriteLine(str.ToString());
            _snwprintf_s(str, (IntPtr)100, (IntPtr)32, "%10d", i);
            Console.WriteLine(str.ToString());
            Console.ReadKey();
        }
    }
