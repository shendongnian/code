    public class SubscribedSubject<T> : ISubject<T>, IDisposable
    {
        private readonly Subject<T> _subject = new Subject<T>();
        private readonly ManualResetEventSlim _subscribed = new ManualResetEventSlim();
        public bool HasObservers => _subject.HasObservers;
        public void Dispose() => _subject.Dispose();
        public void OnCompleted() => Wait().OnCompleted();
        public void OnError(Exception error) => Wait().OnError(error);
        public void OnNext(T value) => Wait().OnNext(value);
        public IDisposable Subscribe(IObserver<T> observer)
        {
            IDisposable disposable = _subject.Subscribe(observer);
            _subscribed.Set();
            return disposable;
        }
        private Subject<T> Wait()
        {
            _subscribed.Wait();
            return _subject;
        }
    }
