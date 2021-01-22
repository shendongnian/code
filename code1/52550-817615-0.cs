    private EventHandler _theEvent;
    private object _eventLock = new object();
    public event EventHandler TheEvent
    {
        add
        {
            lock (_eventLock) 
            { 
                _theEvent -= value; 
                _theEvent += value; 
            }
        }
        remove
        {
            lock (_eventLock) { _theEvent -= value; }
        }
    }
