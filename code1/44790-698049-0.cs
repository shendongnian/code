    [STAThread]
    static void Main()
    {
        var me = Process.GetCurrentProcess();
        var otherMe = Process.GetProcessesByName(me.ProcessName).Where(p => p.Id != me.Id).FirstOrDefault();
        if (otherMe != null)
        {
            otherMe.Kill();
        }
        else
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
