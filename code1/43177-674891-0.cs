    class AContainer : IDisposable
    {
        bool _isDisposed=false;
    
        public void Dispose()
        {
            if (!_isDisposed) 
            {
               // dispose
            }
            _isDisposed=true;
        }
    }
