    using System;
    using System.Diagnostics;
    
    class Launcher
    {
        static void Main()
        {
            Console.WriteLine("Launching launchee");
            Process.Start("Launchee.exe");
            Console.WriteLine("Launched. Exiting");
        }
    }
