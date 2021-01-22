    public class MainClass
    {
        private sealed class AsyncClass
        {
            private int _counter;
            private readonly int _maxCount;
            
            public AsyncClass(int maxCount) { _maxCount = maxCount; }
            
            public void Run()
            {
                while (_counter++ < _maxCount) { Thread.Sleep(1); }
                CompletionTime = DateTime.Now;
            }
            public DateTime CompletionTime { get; private set; }
        }
        private AsyncClass _asyncInstance;
        public void StartAsync()
        {
            var asyncDoneTime = DateTime.MinValue;
            _asyncInstance = new AsyncClass(10);
            Action asyncAction = _asyncInstance.Run;
            asyncAction.BeginInvoke(
                ar =>
                    {
                        asyncAction.EndInvoke(ar);
                        asyncDoneTime = _asyncInstance.CompletionTime;
                    }, null);
            Console.WriteLine("Async task ended at {0}", asyncDoneTime);
        }
    }
