    using System.Diagnostics;
    ...
    private void DumpModuleInfo(IntPtr hProcess)
    {
        uint pid = GetProcessId(hProcess);
        foreach (Process proc in Process.GetProcesses())
        {
            if (proc.Id == pid)
            {
                foreach (ProcessModule pm in proc.Modules)
                {
                    Console.WriteLine("{0:X8} {1:X8} {2:X8} {3}", (int)pm.BaseAddress,
                    (int)pm.EntryPointAddress, (int)pm.BaseAddress + pm.ModuleMemorySize, pm.ModuleName);
                }
            }
        }
    }
