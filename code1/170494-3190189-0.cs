    public class RecycleBin : IDisposable
    {
        private List<IDisposable> _toDispose = new List<IDisposable>();
        public void RememberToDispose(IDisposable disposable)
        {
            _toDispose.Add(disposable);
        }
        public void Dispose()
        {
            foreach(var d in _toDispose)
                d.Dispose();
            _toDispose.Clear();
        }
    }
