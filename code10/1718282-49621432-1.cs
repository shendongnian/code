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
            if(TextFileChecker())
            {
                 Application.Run(new AgentFrm());
            }
            else
            {
                 Application.Run(new LoginFrm());
            }
        }
        
            private bool TextFileChecker()
            {
                 //run a checking method for the textfile
            }
    }
