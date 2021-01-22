    public sealed partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // setting up the Dependency Injection container
            var resolver = ResolverFactory.Get();
            // getting the ILogger or ILog interface
            var logger = resolver.Resolve<ILogger>();
            RegisterGlobalExceptionHandling(logger);
            // Bootstrapping Dependency Injection 
            // injects ViewModel into MainWindow.xaml
            // remember to remove the StartupUri attribute in App.xaml
            var mainWindow = resolver.Resolve<Pages.MainWindow>();
            mainWindow.Show();
        }
        private void RegisterGlobalExceptionHandling(ILogger log)
        {
            // this is the line you really want 
            AppDomain.CurrentDomain.UnhandledException += 
                (sender, args) => CurrentDomainOnUnhandledException(args, log);
            // optional: hooking up some more handlers
            // remember that you need to hook up additional handlers when 
            // logging from other dispatchers, shedulers, or applications
            Application.Dispatcher.UnhandledException += 
                (sender, args) => DispatcherOnUnhandledException(args, log);
            Application.Current.DispatcherUnhandledException +=
                (sender, args) => CurrentOnDispatcherUnhandledException(args, log);
            TaskScheduler.UnobservedTaskException += 
                (sender, args) => TaskSchedulerOnUnobservedTaskException(args, log);
        }
        private static void TaskSchedulerOnUnobservedTaskException(UnobservedTaskExceptionEventArgs args, ILogger log)
        {
            log.Error(args.Exception, args.Exception.Message);
            args.SetObserved();
        }
        private static void CurrentOnDispatcherUnhandledException(DispatcherUnhandledExceptionEventArgs args, ILogger log)
        {
            log.Error(args.Exception, args.Exception.Message);
            // args.Handled = true;
        }
        private static void DispatcherOnUnhandledException(DispatcherUnhandledExceptionEventArgs args, ILogger log)
        {
            log.Error(args.Exception, args.Exception.Message);
            // args.Handled = true;
        }
        private static void CurrentDomainOnUnhandledException(UnhandledExceptionEventArgs args, ILogger log)
        {
            var exception = args.ExceptionObject as Exception;
            var terminatingMessage = args.IsTerminating ? " The application is terminating." : string.Empty;
            var exceptionMessage = exception?.Message ?? "An unmanaged exception occured.";
            var message = string.Concat(exceptionMessage, terminatingMessage);
            log.Error(exception, message);
        }
    }
