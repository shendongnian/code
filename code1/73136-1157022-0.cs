    [STAThread]
    static void Main()
    {
        Taskbar.Hide();
        Form1 TargerForm = new Form1();
        Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        Application.EnableVisualStyles();
        Application.Run(TargerForm);
        Taskbar.Show();
    }
