    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Main main = new Main();
        Application.Run();
        //Application.Run(new Main());
    }
