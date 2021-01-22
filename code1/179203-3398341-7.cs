    private class SomeClass
    {
        private readonly ISleepService _sleepService;
        public SomeClass()
        {
            _sleepService = ServiceLocator.Container.Resolve<ISleepService>();
        }
        public void DoSomething(int interval)
        {
            while (true)
            {
                _sleepService.Sleep(interval);
                break;
            }
        }
    }
