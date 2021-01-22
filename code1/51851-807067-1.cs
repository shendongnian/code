    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Form1 f = new Form1();
        f.Visible = false;
        ApplicationContext context = new ApplicationContext();
        Application.Run(context);        
    }
