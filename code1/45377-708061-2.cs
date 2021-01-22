    class MySingleton<T> : IDisposable
        where T : class
    {
        private T _value;
        private Func<T> _provider;
    
        public MySingleton(Func<T> provider)
        {
            _provider = provider;
        }
    
        public T Get()
        {
            if (_value == null)
            {
                _value = _provider();
            }
    
            return _value;
        }
    
        #region IDisposable Members
    
        public void Dispose()
        {
            if(_value == null)
                return;
    
            IDisposable disposable = _value as IDisposable;
    
            if(disposable != null)
                disposable.Dispose();
        }
    
        #endregion
    }
