    string outputProcess = "";
    string errorProcess = "";
    using (Process process = new Process())
    {
        process.StartInfo.FileName = path;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        outputProcess = process.StandardOutput.ReadToEnd();
        errorProcess = process.StandardError.ReadToEnd();
        process.WaitForExit();
    }
