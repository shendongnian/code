    private static object _stateLocker = new object();
    private static int _someSharedState = 0;
    
    public void SomeAction()
    {
        lock (_stateLocker)
        {
            _someSharedState ++;
        }
    }
    
    public int GetValue()
    {
        lock (_stateLocker)
        {
            return _someSharedState;    }
    }
