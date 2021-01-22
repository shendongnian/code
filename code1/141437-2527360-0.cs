            using System.Diagnostics;
            // ...
            string proc = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(proc);
            if (processes.Length != 3)
            {
                // ...
            }
