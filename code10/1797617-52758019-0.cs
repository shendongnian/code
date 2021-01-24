    [STAThread]
    static void Main() {
        if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());             // Edit as needed
    }
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool SetProcessDPIAware();
