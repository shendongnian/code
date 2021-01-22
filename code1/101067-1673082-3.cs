    public void Print(string pathname, string acrobatDirectory)
    {
        Debug.WriteLine("Printing...");
            
        Printer.Print(pathname, acrobatDirectory);
        Thread.Sleep(30000);
        try
        {
            Debug.WriteLine("Trying to kill runnung AcroRd32.exe's ");
            FindAndKillProcess("AcroRd32");
        }
        catch (Exception)
        {
            Debug.WriteLine("AcroRd32.exe could not be killed...");
        }
    }
    private bool FindAndKillProcess(string name)
    {
        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (clsProcess.ProcessName.StartsWith(name))
            {
                clsProcess.Kill();
                return true;
            }
        }
        return false;
    }
