        foreach (Process p in Process.GetProcesses())
        {
            try
            {
                Console.Write(p.MainModule.FileName + " ");
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + p.Id))
                {
                    foreach (ManagementObject @object in searcher.Get())
                    {
                        Console.Write(@object["CommandLine"] + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Win32Exception ex)
            {
                if ((uint)ex.ErrorCode != 0x80004005)
                {
                    throw;
                }
            }
        }
