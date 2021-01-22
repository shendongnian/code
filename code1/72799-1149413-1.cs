    static class Program
    {
        private static Thread _startupThread = null;
        
        [STAThread]
        static void Main()
        {
            _startupThread = Thread.CurrentThread;
    
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        public static bool IsRunningOnStartupThread()
        {
            return Thread.CurrentThread == _startupThread;
        }
    }
