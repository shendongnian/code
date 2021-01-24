    public static class ObservableExtensions {
        public static CancellableTaskWrapper<T> ToCancellableTask<T>(this IObservable<T> source) {
            return new CancellableTaskWrapper<T>(source);
        }
        public class CancellableTaskWrapper<T> : IDisposable
        {
            private readonly CancellationTokenSource _cts;
            public CancellableTaskWrapper(IObservable<T> source)
            {
                _cts = new CancellationTokenSource();
                Task = source.ToTask(_cts.Token);
            }
            public Task<T> Task { get; }
            public void Dispose()
            {
                _cts.Cancel();
                _cts.Dispose();
            }
        }
    }
