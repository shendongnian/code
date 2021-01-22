    class Message : IDisposable
    {
        private Stopwatch _stopwatch = Stopwatch.StartNew();
        private long _elapsedTicks;
        private string _message;
    
        public Message(string message)
        {
            _message = message;
        }
    
        public void Dispose()
        {
           _elapsedTicks = _stopwatch.ElapsedTicks;
           ... anything else including logging the message ...
        }
    
        ...
    }
