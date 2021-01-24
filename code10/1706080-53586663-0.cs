    ProcessStartInfo start = new ProcessStartInfo();
    start.FileName = "cmd.exe";
    start.Arguments = "/K c:\\path_to_batch\\run_script.bat";
    start.UseShellExecute = false;
    start.RedirectStandardOutput = true;
    start.RedirectStandardError = true;
    start.WorkingDirectory = "c:\\path_to_batch";
    string stdout, stderr;
    using (Process process = Process.Start(start))
    {
        using (StreamReader reader = process.StandardOutput)
        {
            stdout = reader.ReadToEnd();
        }
        using (StreamReader reader = process.StandardError)
        {
            stderr = reader.ReadToEnd();
        }
                
        process.WaitForExit();
    }
