    private Dispatcher _uiDispatcher;
    
    // Call from the main thread
    public void UseThisThreadForEvents()
    {
         _uiDispatcher = Dispatcher.CurrentDispatcher;
    }
    
    // Some method of library that may be called on worker thread
    public void MyMethod()
    {
        if (Dispatcher.CurrentDispatcher != _uiDispatcher)
        {
            _uiDispatcher.Invoke(delegate()
            {
                // UI thread code
            });
        }
        else
        {
             // UI thread code
        }
    }
