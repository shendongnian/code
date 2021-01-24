    class Producer
    {
        private Queue<int> _queue = new Queue<int>();
        private Subject<int> _whenEnqueued = new Subject<int>();
        
        public IObservable<int> WhenEnqueued => _whenEnqueued.AsObservable();        
        public void Enqueue(int value)
        {
            _queue.Enqueue(value);
            _whenEnqueued.OnNext(value);
        }
    }
