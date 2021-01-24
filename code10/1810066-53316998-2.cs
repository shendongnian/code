    /// <summary>
    /// Warning: might not be as performant (and safe?) as the Lazy<T>, see: 
    /// https://codereview.stackexchange.com/questions/207708/own-implementation-of-lazyt-object
    /// </summary>
    public class MyLazy<T>
    {
        private T               _Value;
        private volatile bool   _Loaded;
        private object          _Lock = new object();
    
    
        public T Get(Func<T> create)
        {
            if ( !_Loaded )
            {
                lock (_Lock)
                {
                    if ( !_Loaded ) // double checked lock
                    {
                        _Value   = create();
                        _Loaded = true;
                    }
                }
            }
    
            return _Value;
        } 
    
    
        public void Invalidate()
        {
            lock ( _Lock )
                _Loaded = false;
        }
    }
