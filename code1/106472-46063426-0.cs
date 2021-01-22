     public class WatcherWrapper : IDisposable
    {
        private readonly FileSystemWatcher _fileWatcher;
        private readonly Subject<FileSystemEventArgs> _infoSubject;
        private Subject<FileSystemEventArgs> _eventSubject;
        public WatcherWrapper(string path, string nameFilter = "*.*", NotifyFilters? notifyFilters = null)
        {
            _fileWatcher = new FileSystemWatcher(path, nameFilter);
            if (notifyFilters != null)
            {
                _fileWatcher.NotifyFilter = notifyFilters.Value;
            }
            _infoSubject = new Subject<FileSystemEventArgs>();
            _eventSubject = new Subject<FileSystemEventArgs>();
            Observable.FromEventPattern<FileSystemEventArgs>(_fileWatcher, "Changed").Select(e => e.EventArgs)
                .Distinct(e => e.FullPath).Subscribe(_infoSubject.OnNext);
            Observable.FromEventPattern<FileSystemEventArgs>(_fileWatcher, "Created").Select(e => e.EventArgs)
                .Distinct(e => e.FullPath).Subscribe(_infoSubject.OnNext);
            Observable.FromEventPattern<FileSystemEventArgs>(_fileWatcher, "Deleted").Select(e => e.EventArgs)
                .Distinct(e => e.FullPath).Subscribe(_infoSubject.OnNext);
            Observable.FromEventPattern<FileSystemEventArgs>(_fileWatcher, "Renamed").Select(e => e.EventArgs)
                .Distinct(e => e.FullPath).Subscribe(_infoSubject.OnNext);
            // this takes care of double events and still works with changing the name of the same file after a while
            _infoSubject.Buffer(TimeSpan.FromMilliseconds(20))
                .Select(x => x.GroupBy(z => z.FullPath).LastOrDefault()).Subscribe(
                    infos =>
                    {
                        if (infos != null)
                            foreach (var info in infos)
                            {
                                {
                                    _eventSubject.OnNext(info);
                                }
                            }
                    });
            _fileWatcher.EnableRaisingEvents = true;
        }
        public IObservable<FileSystemEventArgs> FileEvents => _eventSubject;
        public void Dispose()
        {
            _fileWatcher?.Dispose();
            _eventSubject.Dispose();
            _infoSubject.Dispose();
        }
    }
