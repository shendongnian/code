    Timer timer = new Timer(_ =>
    {
        Process p = new Process();
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.FileName = "foobar.exe";
        p.Start();
        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        switch (output)
        {
        case "InProgress":
            // ...
            break;
        case "Finished":
            // ...
            break;
        }
    });
    timer.Change(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(3));
