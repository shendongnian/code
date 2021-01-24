    internal class SimpleDispatcherContext : SynchronizationContext
    {
        private readonly Dispatcher _dispatcher;
        private readonly DispatcherPriority _priority;
        public SimpleDispatcherContext(Dispatcher dispatcher, DispatcherPriority priority = DispatcherPriority.Normal)
        {
            _dispatcher = dispatcher;
            _priority = priority;
        }
        public override void Post(SendOrPostCallback d, object state) {
            var op = this._dispatcher.BeginInvoke(_priority, d, state);
            // here, default sync context just does nothing
            if (op.Status == DispatcherOperationStatus.Aborted)
                throw new OperationCanceledException("Dispatcher has shut down");
        }
        public override void Send(SendOrPostCallback d, object state) {
            _dispatcher.Invoke(d, _priority, state);
        }
    }
    private async Task LoadData()
    {
        SynchronizationContext.SetSynchronizationContext(new SimpleDispatcherContext(Dispatcher));
        // Fetch data
        var data = await FetchData();
    
        // Display data
        // ...
    }
