    using System.Runtime.InteropServices;
    
    namespace Test
    {
        /// <summary>
        /// This function will attach to the console given a specific ProcessID for that Console, or
        /// the program will attach to the console it was launched if -1 is passed in.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();
    
    
        [STAThread]
        public static void Main() 
        {	
            Application.ApplicationExit +=new EventHandler(Application_ApplicationExit);
            string[] commandLineArgs = System.Environment.GetCommandLineArgs();
    
            if(commandLineArgs[0] == "-cmd")
            {
                //attaches the program to the running console to map the output
                AttachConsole(-1);
            }
            else
            {
                //Open new form and do UI stuff
                Form f = new Form();
                f.ShowDialog();
            }
    
        }
    
        /// <summary>
        /// Handles the cleaning up of resources after the application has been closed
        /// </summary>
        /// <param name="sender"></param>
        public static void Application_ApplicationExit(object sender, System.EventArgs e)
        {
            FreeConsole();
        }
    }
