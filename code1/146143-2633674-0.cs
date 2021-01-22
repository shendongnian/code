        foreach (Process p in Process.GetProcesses())
        {
            Console.Write(p.StartInfo.FileName + " ");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + p.Id))
            {
                foreach (ManagementObject @object in searcher.Get())
                {
                    Console.Write(@object["CommandLine"] + " ");
                }
                Console.WriteLine();
            }
        }
