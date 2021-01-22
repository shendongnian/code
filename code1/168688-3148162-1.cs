    Process process = new Process();
    process.StartInfo.FileName = executable;
    process.StartInfo.Arguments = arguments;
    process.StartInfo.ErrorDialog = true;
    process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
    process.Start();
    process.WaitForExit(1000 * 60 * 5);    // Wait up to five minutes.
