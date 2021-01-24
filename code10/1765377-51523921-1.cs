    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            SteamAPI.Init();
        }
    }
