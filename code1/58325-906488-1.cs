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
            SingleInstanceApplication.Run(new Form1(), StartupNextInstanceEventHandler);
        }
        public static void StartupNextInstanceEventHandler(object sender, StartupNextInstanceEventArgs e)
        {
            MessageBox.Show("New instance");
        }
    }
