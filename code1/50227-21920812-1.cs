        static bool restart = true; // A variable that is accessible from program
        static int restartCount = 0; // Count the number of restarts
        static int maxRestarts = 3;  // Maximum restarts before quitting the program
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (restart && restartCount < maxRestarts)
            {
               restart = false; // if you like.. the program can set it to true again
               restartCount++;  // mark another restart,
                                // if you want to limit the number of restarts
                                // this is useful if your program is crashing on 
                                // startup and cannot close normally as it will avoid
                                // a potential infinite loop
               try {
                  Application.Run(new YourMainForm());
               }
               catch {  // Application has crashed
                  restart = true;
               }
            }
        }
