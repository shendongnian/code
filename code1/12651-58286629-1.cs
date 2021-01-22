C#
    var cliProcess = new Process() {
        StartInfo = new ProcessStartInfo("echo", "Hello, World") {
            UseShellExecute = false,
            RedirectStandardOutput = true
        }
    };
    cliProcess.Start();
    string cliOut = cliProcess.StandardOutput.ReadToEnd();
    cliProcess.WaitForExit();
    cliProcess.Close();
