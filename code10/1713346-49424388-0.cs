    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);    
            this.ShutdownMode = System.Windows.ShutdownMode.OnLastWindowClose;
        }
    }
