    private void Application_ApplicationExit(object sender, EventArgs e)
    {
        var process = new ProcessStartInfo("notepad.exe");
        Process.Start(process);
    }
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        var process = new ProcessStartInfo("notepad.exe");
        Process.Start(process);
    }
