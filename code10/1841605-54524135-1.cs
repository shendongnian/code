    public static int RunPowershellScript(string ps)
    {
        int errorLevel;
        ProcessStartInfo processInfo;
        Process process;
        
        processInfo = new ProcessStartInfo("powershell.exe", "-File " + ps);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        
        process = Process.Start(processInfo);
        process.WaitForExit();
        
        errorLevel = process.ExitCode;
        process.Close();
        
        return errorLevel;
    }
