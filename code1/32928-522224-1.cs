    static class Program {
        internal static Boolean UserExitCalled;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Setup your tray icon here
            while (!UserExitCalled) {
                Application.DoEvents(); // Process windows messages
                Thread.Sleep(1);
            }
            return;
        }
    }
