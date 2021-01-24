    public Application()
    {
        ...
        lock(_globalLock)
        {
            if (_appCreatedInThisAppDomain == false)
            {
                ...
                _appInstance = this;
                ...
                _appCreatedInThisAppDomain = true;
            }
            else
            {
                throw new InvalidOperationException(...);
            }
        }
    }
    ...
    static private object                           _globalLock;
    static private bool                             _appCreatedInThisAppDomain;
    static private Application                      _appInstance;
    ...
