        static bool restart = true; // A variable that is accessible from program
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (restart)
            {
               restart = false; // if you like.. the program can set it to true again
               try {
                  Application.Run(new YourMainForm());
               }
               catch {  // Application has crashed
                  restart = true;
               }
            }
        }
