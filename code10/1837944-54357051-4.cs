       public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                base.OnStartup(e);
                this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            }
            void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
            {
             //Your code
            }
        }
