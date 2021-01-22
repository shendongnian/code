    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace ProcessLauncher
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process process = Process.Start("MemoryHog.exe", "6000 2000");
                Console.Read();
                process.Kill();
    
            }
        }
    }
