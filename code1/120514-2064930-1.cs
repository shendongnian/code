    public void process_file(FileInfo fi, Action<string> dataCallback)
    {
        myProcess = new Process();
        ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("perl.exe");
        myProcessStartInfo.Arguments = "perly.pl";
        myProcessStartInfo.UseShellExecute = false;
        myProcessStartInfo.RedirectStandardOutput = true;
        myProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        myProcessStartInfo.CreateNoWindow = true;
        myProcess.StartInfo = myProcessStartInfo;
        myProcess.OutputDataReceived += (sender, e) =>
            {
                dataCallback(e.Data);
            };
        myProcess.Start();
        myProcess.BeginOutputReadLine();
    }
