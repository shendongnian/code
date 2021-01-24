    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            base.OnStartup(e);
        }
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).host.Close();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            if (((MainWindow)Application.Current.MainWindow).host.State == System.ServiceModel.CommunicationState.Opened)
                ((MainWindow)Application.Current.MainWindow).host.Close();
            base.OnExit(e);
        }
    
