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
            SystemTrayApp systemTrayApp = new SystemTrayApp();
            systemTrayApp.Text = "File Copy Service Controller";
    
            // Show the instance of the form modally.
            systemTrayApp.ShowInTaskbar = true;
            systemTrayApp.ShowDialog();
            Application.Run();
        }
     }
