    using System;
    using System.Diagnostics;
    
    class Test
    {
        static void Main()
        {
            ProcessStartInfo psi = new ProcessStartInfo("test.txt");
            psi.UseShellExecute = true;
            Process.Start(psi);
        }
    }
