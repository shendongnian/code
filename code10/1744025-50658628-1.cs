    [STAThread]
    static void Main()
    {
        string folderName = null ;
        if (Environment.GetCommandLineArgs().Length > 1)
            folderName = Environment.GetCommandLineArgs()[1];
        MessageBox.Show(folderName);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(true);
        Application.Run(new Form1());
    }
