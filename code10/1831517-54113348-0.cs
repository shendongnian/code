    public class DualBag<T> : IDisposable
    {
        private ConcurrentBag<T> _bag;
        private int _threshold;
        private ManualResetEventSlim _exchangeEvent;
        private CancellationTokenSource _cts;
        public DualBag(int threshold)
        {
            _bag = new ConcurrentBag<T>();
            _threshold = threshold;
            _exchangeEvent = new ManualResetEventSlim();
            _cts = new CancellationTokenSource();
            Task.Run(() => Consume());
        }
        public void Add(T item)
        {
            _bag.Add(item);
            if (_bag.Count > _threshold)
            {
                _exchangeEvent.Set();
            }
        }
        private async Task Consume()
        {
            while (!_cts.IsCancellationRequested)
            {
                _exchangeEvent.Wait();
                _exchangeEvent.Reset();
                var _replacementBag = new ConcurrentBag<T>();
                var bag = Interlocked.Exchange(ref _bag, _replacementBag);
                await ConsumeBag(bag);
            }
            if (!_bag.IsEmpty)
                await ConsumeBag(_bag);
        }
        public void Dispose()
        {
            _cts.Cancel();
        }
        public Task ConsumeBag(ConcurrentBag<T> bag)
        {
            // post entries to the api
        }
    }
