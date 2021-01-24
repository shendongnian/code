    static void Main()
    {
        Program myProgram = this;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        MainForm = new Form1(ref myProgram);
        Application.Run(MainForm);
    }
