    using System;
    using System.Diagnostics;
    
    public class Test
    {
        static void Main()
        {
            Process p = new Process { 
                StartInfo = new ProcessStartInfo("C:\\Windows\\notepad.exe")
            };
            p.Start();
            Console.WriteLine("See, I'm still running");
        }
    }
