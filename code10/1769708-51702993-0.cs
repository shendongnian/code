    public partial class App : Application
    {
        public App()
        {
            SetupExceptionHandlingInApp();
        }
        private static void SetupExceptionHandlingInMain()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                //log
            };
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                //log
            };
        }
        private void SetupExceptionHandlingInApp()
        {            
            this.DispatcherUnhandledException += (s, e) =>
            {
                //log
            };                      
        }
        [STAThread]
        public static void Main()
        {
            SetupExceptionHandlingInMain();
            var app = new App();
            throw new Exception();
        }
