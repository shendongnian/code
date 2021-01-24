    private bool _isRunning = false;
    public void OnActionEnded()
    {
        lock (_lockObj)
        {
            try
            {
                _isRunning = true;
                IsInAction = false;
                foreach (var trigger in _triggers)
                    trigger();
                _triggers.Clear();
            }
            finally
            {
                _isRunning = false;
            }
        }
    }
    public void OnActionStarted()
    {
        lock (_lockObj)
        {        
            if (_isRunning)
                throw new NotSupportedException();
            IsInAction = true;
        }
    }
