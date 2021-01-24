    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Global.DevMode = Boolean.Parse(e.Args.FirstOrDefault().ToString().Split(':')[1]);
        }
    }
