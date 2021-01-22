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
            //Add this line
            Application.ApplicationExit +=
                                new EventHandler(Application_ApplicationExit);
            Application.Run(new Form1());
        }
        //and this method:
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
