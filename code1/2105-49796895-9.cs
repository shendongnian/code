    using System.Diagnostics;
    static void Main()
    {
        Process thisProcess = Process.GetCurrentProcess();
        Process[] allProcesses = Process.GetProcessesByName(thisProcess.ProcessName);
        if (allProcesses.Length > 1)
        {
            // Don't put a MessageBox in here because the user could spam this MessageBox.
            return;
        }
        // Optional code. If you don't want that someone runs your ".exe" with a different name:
        string exeName = AppDomain.CurrentDomain.FriendlyName;
        // in debug mode, don't forget that you don't use your normal .exe name.
        // Debug uses the .vshost.exe.
        if (exeName != "the name of your executable.exe") 
        {
            // You can add a MessageBox here if you want.
            // To point out to users that the name got changed and maybe what the name should be or something like that^^ 
            MessageBox.Show("The executable name should be \"the name of your executable.exe\"", 
                "Wrong executable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        // Following code is default code:
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
