    class Program {
        private static CustomContext appContext;
    
        [STAThread]
        public static void Main() {
           // Init code
           //...
           appContext = new CustomContext();
           Application.Run(appContext);
        }
        public static Quit() {
            appContext.ExitThread();
        }
    }
