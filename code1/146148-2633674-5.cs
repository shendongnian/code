    private static void Main()
    {
        foreach (var process in Process.GetProcesses())
        {
            try
            {
                Console.WriteLine(process.GetCommandLine());
            }
            catch (Win32Exception ex) when ((uint)ex.ErrorCode == 0x80004005)
            {
                // Intentionally empty.
            }
        }
    }
    private static string GetCommandLine(this Process process)
    {
        var commandLine = new StringBuilder(process.MainModule.FileName);
        commandLine.Append(" ");
        using (var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
        {
            foreach (var @object in searcher.Get())
            {
                commandLine.Append(@object["CommandLine"]);
                commandLine.Append(" ");
            }
        }
        return commandLine.ToString();
    }
