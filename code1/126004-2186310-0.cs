    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppContext = new ApplicationContext();
            AppContext.MainForm = new Form1();
            Application.Run(AppContext);
        }
        public static ApplicationContext AppContext;
    }
