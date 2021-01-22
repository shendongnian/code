    var jobProcess = new Process();
    jobProcess.StartInfo.FileName = Assembly.GetExecutingAssembly().Location;
    jobProcess.StartInfo.Arguments = "job";
    jobProcess.StartInfo.CreateNoWindow = false;
    jobProcess.StartInfo.UseShellExecute = false;
    jobProcess.StartInfo.RedirectStandardInput = true;
    jobProcess.StartInfo.RedirectStandardOutput = true;
    jobProcess.StartInfo.RedirectStandardError = true;
    // Just Console.WriteLine it.
    jobProcess.ErrorDataReceived += jp_ErrorDataReceived;
    jobProcess.Start();
    jobProcess.BeginErrorReadLine();
    try
    {
        jobProcess.StandardInput.WriteLine(url);
        var buf = new byte[int.Parse(jobProcess.StandardOutput.ReadLine())];
        jobProcess.StandardOutput.BaseStream.Read(buf, 0, buf.Length);
        return Deserz<Bitmap>(buf);
    }
    finally
    {
        if (jobProcess.HasExited == false)
            jobProcess.Kill();
    }
