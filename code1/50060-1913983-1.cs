    static class Program {
        private static Mutex mutex;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool createdNew = true;
            mutex = new Mutex(true, @"Global\Test", out createdNew);
            if (createdNew) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());        
            }
            else {
                MessageBox.Show(
                    "Application is already running",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
