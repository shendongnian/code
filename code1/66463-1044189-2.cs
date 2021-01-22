    string output;
    string error;
    System.Diagnostics.Process p = new System.Diagnostics.Process
        {
            StartInfo =
            {
                FileName = program,
                Arguments = args,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                UseShellExecute = false,
            }
        };
    if (waitForExit)
    {
        StringBuilder sb = new StringBuilder();
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        Action<Object,DataReceivedEventArgs> stdErrorRead = (o,e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
                sb.Append(e.Data);
        };
        p.ErrorDataReceived += stdErrorRead;
        p.Start();
        // begin reading stderr asynchronously
        p.BeginErrorReadLine();
        // read stdout synchronously
        output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        // return code is in p.ExitCode
        if (sb.Length > 0)
            error= sb.ToString();
    }
