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
            PreJitControls();
            Application.Run(new Form1());
        }
        private static void PreJitControls()
        {           
            ThreadPool.QueueUserWorkItem((t) =>
            {
                Thread.Sleep(1000); // Or whatever reasonable amount of time
                try
                {
                    AssemblyPullingControl1 c = new AssemblyPullingControl1();
                }
                catch (Exception) { }
                try
                {
                    AssemblyPullingControl2 c = new AssemblyPullingControl2();
                }
                catch (Exception) { }
            });
        }
    }
