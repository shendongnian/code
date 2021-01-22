    Process process = new Process();
            
    do
    {
        process.StartInfo.FileName = "shutdown.exe";
        process.StartInfo.Arguments = "/a";
        process.Start();
        process.WaitForExit();
        MessageBox.Show(string.Format("ExitCode={0}",process.ExitCode));
        Thread.Sleep(1000);
    }
    while (process.ExitCode != 0) ;
