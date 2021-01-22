    public static class FileSystemWatcherExtensions
    {
        public static IDisposable OnAnyEvent(this FileSystemWatcher source,
            WatcherChangeTypes changeTypes, FileSystemEventHandler handler, int delay)
        {
            var cancellations = new Dictionary<string, CancellationTokenSource>(
                StringComparer.OrdinalIgnoreCase);
            var locker = new object();
            if (changeTypes.HasFlag(WatcherChangeTypes.Created))
                source.Created += FileSystemWatcher_Event;
            if (changeTypes.HasFlag(WatcherChangeTypes.Deleted))
                source.Deleted += FileSystemWatcher_Event;
            if (changeTypes.HasFlag(WatcherChangeTypes.Changed))
                source.Changed += FileSystemWatcher_Event;
            if (changeTypes.HasFlag(WatcherChangeTypes.Renamed))
                source.Renamed += FileSystemWatcher_Event;
            return new Disposable(() =>
            {
                source.Created -= FileSystemWatcher_Event;
                source.Deleted -= FileSystemWatcher_Event;
                source.Changed -= FileSystemWatcher_Event;
                source.Renamed -= FileSystemWatcher_Event;
            });
            async void FileSystemWatcher_Event(object sender, FileSystemEventArgs e)
            {
                var key = e.FullPath;
                var cts = new CancellationTokenSource();
                lock (locker)
                {
                    if (cancellations.TryGetValue(key, out var existing))
                    {
                        existing.Cancel();
                    }
                    cancellations[key] = cts;
                }
                try
                {
                    await Task.Delay(delay, cts.Token);
                    // Omitting ConfigureAwait(false) is intentional here.
                    // Continuing in the captured context is desirable.
                }
                catch (TaskCanceledException)
                {
                    return;
                }
                lock (locker)
                {
                    if (cancellations.TryGetValue(key, out var existing)
                        && existing == cts)
                    {
                        cancellations.Remove(key);
                    }
                }
                cts.Dispose();
                handler(sender, e);
            }
        }
        public static IDisposable OnAllEvents(this FileSystemWatcher source,
            FileSystemEventHandler handler, int delay)
            => OnAnyEvent(source, WatcherChangeTypes.All, handler, delay);
        public static IDisposable OnCreated(this FileSystemWatcher source,
            FileSystemEventHandler handler, int delay)
            => OnAnyEvent(source, WatcherChangeTypes.Created, handler, delay);
        public static IDisposable OnDeleted(this FileSystemWatcher source,
            FileSystemEventHandler handler, int delay)
            => OnAnyEvent(source, WatcherChangeTypes.Deleted, handler, delay);
        public static IDisposable OnChanged(this FileSystemWatcher source,
            FileSystemEventHandler handler, int delay)
            => OnAnyEvent(source, WatcherChangeTypes.Changed, handler, delay);
        public static IDisposable OnRenamed(this FileSystemWatcher source,
            FileSystemEventHandler handler, int delay)
            => OnAnyEvent(source, WatcherChangeTypes.Renamed, handler, delay);
        private struct Disposable : IDisposable
        {
            private readonly Action _action;
            internal Disposable(Action action) => _action = action;
            public void Dispose() => _action?.Invoke();
        }
    }
