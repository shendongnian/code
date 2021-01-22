    private static void Main()
    {
        foreach (var p in Process.GetProcesses())
        {
            try
            {
                Console.WriteLine(GetCommandLine(p));
            }
            catch (Win32Exception ex)
            {
                if ((uint)ex.ErrorCode != 0x80004005)
                {
                    throw;
                }
            }
        }
    }
    private static string GetCommandLine(Process p)
    {
        var commandLine = new StringBuilder(p.MainModule.FileName + " ");
        using (var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + p.Id))
        {
            foreach (var @object in searcher.Get())
            {
                commandLine.Append(@object["CommandLine"] + " ");
            }
        }
        return commandLine.ToString();
    }
