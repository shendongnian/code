    using System;
    using System.Runtime.InteropServices;
    public class Program
    {
        [DllImport ("libc")]
        public static extern uint getuid ();
        public static void Main()
        {
            if (getuid() == 0) {
                System.Console.WriteLine("I'm running as root!");
            } else {
                System.Console.WriteLine("Not root...");
            }
        }
    }
