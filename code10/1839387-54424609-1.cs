    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message);
            Environment.Exit(0);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!SomeCondition)
                Application.Current.Shutdown();
        }
    }
