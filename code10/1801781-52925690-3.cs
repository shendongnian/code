    public partial class App : Application
    {
       protected override void OnStartup(StartupEventArgs e)
       {
          MessageBox.Show(
             MutexManager.CreateApplicationMutex()
                         .ToString());
          base.OnStartup(e);
       }
    }
