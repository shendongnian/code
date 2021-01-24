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
            //Properties.Settings.Default.Reset();
           if(Properties.Settings.Default.path == "" )
           
            {
                Application.Run(new FolderSetting());
            }
            else
            {
                Application.Run(new Form1());
            }
          
        }
    }
