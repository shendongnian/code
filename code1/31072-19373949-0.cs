    class EventWaiter<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly Action<EventHandler<TEventArgs>> _unsubHandler;
        private readonly Action<EventHandler<TEventArgs>> _subHandler;
        public EventWaiter(Action<EventHandler<TEventArgs>> subHandler, Action<EventHandler<TEventArgs>> unsubHandler)
        {
            _unsubHandler = unsubHandler;
            _subHandler = subHandler;
        }
        protected void Handler(object sender, TEventArgs args)
        {
            _unsubHandler.Invoke(Handler);
            TaskCompletionSource.SetResult(args);
        }
        public  TEventArgs WaitOnce()
        {
            TaskCompletionSource = new TaskCompletionSource<TEventArgs>();
            _subHandler.Invoke(Handler);
            return TaskCompletionSource.Task.Result;
        }
        protected TaskCompletionSource<TEventArgs> TaskCompletionSource { get; set; } 
    }
 
