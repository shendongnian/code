    using System;
    using System.Diagnostics;
    
    public class Test
    {
        static void Main()
        {
            Process proc = Process.Start("image.tif");
            Console.WriteLine(proc == null);
        }
    }
