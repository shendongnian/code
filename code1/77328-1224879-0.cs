    process = new Process();
    process.StartInfo.UseShellExecute = true;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.CreateNoWindow = false;
    process.StartInfo.FileName = FileName;
    process.StartInfo.Arguments = Arguments;
    process.StartInfo.WorkingDirectory = WorkingDirectory;
    process.Start();
