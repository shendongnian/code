    using System.Threading;
    
    public StringBuilder Builder
    {
        get 
        {
            if (_builder != null)
                Interlocked.CompareExchange( ref _builder, new StringBuilder(), null );
            return _builder; 
        }
    }
