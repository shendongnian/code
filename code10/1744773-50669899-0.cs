    public class DisposerProperty<T> : IDisposable, IObservable<T> where T : IDisposable
    {
        private IDisposable Subscription { get; }
        private IObservable<T> Source { get; }
        public T Value { get; private set; }
        public DisposerProperty(IObservable<T> source, T defaultValue = default)
        {
            Value = defaultValue;
            Source = source;
            Subscription = source.Subscribe(t =>
                                            {
                                                Value?.Dispose();
                                                Value = t;
                                            });
        }
        public void Dispose() => Subscription.Dispose();
        /// <inheritdoc />
        public IDisposable Subscribe(IObserver<T> observer) => Source.Subscribe(observer);
    }
