    static void Main(string[] args)
    {
        ExecuteProcesses(new string[] { "test1.bat", "test2.bat", "test3.bat" });
    }
    public static void ExecuteProcesses(string[] executablesPaths)
    {
        using (Process process = new Process())
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            process.StartInfo = processStartInfo;
            foreach (string executablePath in executablesPaths)
            {
                process.StartInfo.FileName = executablePath;
                process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                process.WaitForExit();
            }
        }
    }
