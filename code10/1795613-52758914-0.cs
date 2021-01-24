    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
             RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
        }
    }
