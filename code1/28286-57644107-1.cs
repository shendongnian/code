    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (_orderCacheLock != null)
                _orderCacheLock.Dispose();
    
            if(_SettingTradeTimeOut!=null)
                _SettingTradeTimeOut.Dispose();
    
            _orderCacheLock = null;
    #if DEBUG
            CheckEventHasNoSubscribers(OnIsProfitable);
            CheckEventHasNoSubscribers(OnPropertyChanged);
    #endif
            disposedValue = true;
        }
    }
