    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (DialogResult.OK == new LoginForm().ShowDialog())
            {
                Application.Run(new MainForm());
            }
        }
    }
