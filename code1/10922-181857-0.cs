    Process process = new Process();
    // Configure the process using the StartInfo properties.
    process.StartInfo.FileName = "process.exe";
    process.StartInfo.Arguments = "-n";
    process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
    process.Start();
    process.WaitForExit();// Waits here for the process to ecit.
