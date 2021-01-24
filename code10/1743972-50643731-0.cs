    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetupSystemTrayIcon();
            var showConsole = args.Any(x => x.ToLowerInvariant().Contains("showconsole"));
            StartService(showConsole);
        }
    }
