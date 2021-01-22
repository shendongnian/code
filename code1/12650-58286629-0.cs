C#
    var cliProcess = new Process() {
        StartInfo = new ProcessStartInfo("echo", "Hello, World")
    };
    cliProcess.Start();
    string cliOut = cliProcess.StandardOutput.ReadToEnd();
    cliProcess.WaitForExit();
    cliProcess.Close();
