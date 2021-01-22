    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args.Length > 0)
                ((Window1) MainWindow).SetProjectFile(e.Args[0]);
        }
    }
