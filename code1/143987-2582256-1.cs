    public sealed class AutomationManager
    {
        private readonly BusyLock _automationLock = new BusyLock();
        public IDisposable AutomationLock
        {
            get { return _automationLock.Enter(); }
        }
        public bool IsBusy
        {
            get { return _automationLock.IsBusy; }
        }
    }
