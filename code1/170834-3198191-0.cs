    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppContext = new ApplicationContext();
            Application.Run(AppContext);
        }
        public static void Quit() {
            AppContext.ExitThread();
        }
        public static ApplicationContext AppContext;
    }
