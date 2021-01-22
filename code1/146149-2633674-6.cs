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
                // Intentionally empty - no security access to the process.
            }
            catch (InvalidOperationException)
            {
                // Intentionally empty - the process exited before getting details.
            }
        }
    }
    private static string GetCommandLine(this Process process)
    {
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
        using (ManagementObjectCollection objects = searcher.Get())
        {
            return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
        }
    }
