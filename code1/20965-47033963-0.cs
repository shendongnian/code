    using System.Runtime.InteropServices;
            [DllImport("kernel32.dll")]
            public static extern bool Beep(int freq, int duration);
    
            public static void TestBeeps()
            {
                Beep(1000, 1600); //low frequency, longer sound
                Beep(2000, 400); //high frequency, short sound
            }
