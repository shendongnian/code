    public class SampleThreadSafeDisposableClass: IDisposable
    {
        bool _isDisposed;
        object _syncObj = new object();
        List<object> _list = new List<object>();
        public void Add(object obj)
        {
            lock(_syncObj)
            {
                if (_isDisposed)
                    return;
                _list.Add(obj);
            }
        }       
        //This method can be Dispose/Clear/CancelAll
        public void Dispose()
        {
            lock (_syncObj)
            {
                if (_isDisposed)
                    return;
                _isDisposed = true;
                _list.Clear();
            }
        }
    }
