    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread t1 = new Thread(Main_);
            Thread t2 = new Thread(Main_);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
        static void Main_()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
