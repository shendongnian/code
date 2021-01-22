    // From the above link:
    // the exposed event
    public event EventHandler MyEvent
    
    // multicast delegate field
    private EventHandler _myEvent;
        
    // property-like add & remove handlers
    public event EventHandler MyEvent 
    {
        add
        {
            lock (this)
            {
                _myEvent += value;
            }
        }
        remove
        {
            lock (this)
            {
                _myEvent -= value;
            }
        }        
    }
