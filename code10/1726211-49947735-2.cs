    [Export]
    public class Consumer
    {
        private readonly ISchedulerProvider _schedulerProvider;
        [ImportingConstructor]
        public Consumer(ISchedulerProvider schedulerProvider)
        {
            _schedulerProvider = schedulerProvider;
        }
        public string GetFoo()
        {
            return _schedulerProvider.Foo;
        }
    }
