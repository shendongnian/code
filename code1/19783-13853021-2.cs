    // Program.cs
    static void Main()
    {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // it is important to open paradox connection before creating
            // the first form in the project
            if (!Data.OpenParadoxDatabase())
                return;
            Application.Run(new MainForm());
    }
