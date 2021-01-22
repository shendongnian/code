    public class SingleApplication : Application
    {
        private Mutex mutex;
        private bool mutexCreated;
    
        public SingleApplication()
        {
            string mutexId = $"Global\\{GetType().GUID}";
            MutexAccessRule allowEveryoneRule = new MutexAccessRule(
                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                MutexRights.FullControl, 
                AccessControlType.Allow);
            MutexSecurity securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);
            // initiallyOwned: true == false + mutex.WaitOne()
            mutex = new Mutex(initiallyOwned: true, mutexId, out mutexCreated, securitySettings);        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            if (mutexCreated)
            {
                try
                {
                    mutex.ReleaseMutex();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
