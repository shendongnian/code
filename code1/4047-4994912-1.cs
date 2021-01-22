    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // splash screen, which is terminated in FormMain
            FormSplash.ShowSplash();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // this is probably where your heavy lifting is:
            Application.Run(new FormMain());
        }
    }
