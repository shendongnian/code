    class Program {
        private static CustomContext appContext;
    
        [STAThread]
        public static void Main() {
           // Init code
           //...
           appContext = new CustomContext();
           Application.Run(appContext);
        }
        public static void Quit() {
            appContext.ExitThread();
        }
    }
