    class RealDispatcher : IDispatcher
    {
        private readonly Dispatcher _dispatcher;
    
        public RealDispatcher(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
    
        public void BeginInvoke(Delegate method, params object[] args)
        {
            _dispatcher.BeginInvoke(method, args);
        }
    }
