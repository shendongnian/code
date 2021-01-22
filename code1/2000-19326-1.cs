    public class SingleInstanceManager : Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {
        private SingleInstanceApplication _application;
        private System.Collections.ObjectModel.ReadOnlyCollection<string> _commandLine;
        public SingleInstanceManager()
        {
            IsSingleInstance = true;
        }
        protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
        {
            // First time _application is launched
            _commandLine = eventArgs.CommandLine;
            _application = new SingleInstanceApplication();
            _application.Run();
            return false;
        }
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            // Subsequent launches
            base.OnStartupNextInstance(eventArgs);
            _commandLine = eventArgs.CommandLine;
            _application.Activate();
        }
    }
