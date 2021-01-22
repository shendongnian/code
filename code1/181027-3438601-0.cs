    get {
        if( _instance == null) {
            var singleton = new Singleton();
            if(System.Threading.Interlocked.CompareExchange(ref _instance, singleton, null) != null) {
                if (singleton is IDisposable) singleton.Dispose();
            }
        }
        return _instance;
    }
