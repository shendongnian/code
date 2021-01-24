    public class SubscribedSubject<T> : ISubject<T>, IDisposable
    {
        private readonly Subject<T> _subject = new Subject<T>();
        private readonly ManualResetEventSlim _subscribed = new ManualResetEventSlim();
        public bool HasObservers => _subject.HasObservers;
        public void Dispose() => _subject.Dispose();
        public void OnCompleted() => Wait(() => _subject.OnCompleted());
        public void OnError(Exception error) => Wait(() => _subject.OnError(error));
        public void OnNext(T value) => Wait(() => _subject.OnNext(value));
        public IDisposable Subscribe(IObserver<T> observer)
        {
            IDisposable disposable = _subject.Subscribe(observer);
            _subscribed.Set();
            return disposable;
        }
        private void Wait(Action action)
        {
            _subscribed.Wait();
            action();
        }
    }
