    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!SomeCondition)
                Application.Current.Shutdown();
        }
    }
