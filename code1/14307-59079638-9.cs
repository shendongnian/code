    public class SingleApplication : Application
    {
        private static Mutex mutex;
        private static bool mutexCreated;
    
        static SingleApplication()
        {
            mutex = new Mutex(true, Assembly.GetEntryAssembly().FullName, out mutexCreated);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            mutex.Dispose();
        }
    
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!mutexCreated)
            {
                 MessageBox.Show("Already started!");
                Shutdown();
            }
        }
    }
