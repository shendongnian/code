    private static void Main()
    {
        foreach (var process in Process.GetProcesses())
        {
            try
            {
                Console.WriteLine(GetCommandLine(process));
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
    private static string GetCommandLine(Process process)
    {
        var commandLine = new StringBuilder(process.MainModule.FileName + " ");
        using (var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
        {
            foreach (var @object in searcher.Get())
            {
                commandLine.Append(@object["CommandLine"] + " ");
            }
        }
        return commandLine.ToString();
    }
