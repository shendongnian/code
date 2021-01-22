    SomeEventHandler someEvent;
    readonly object someEventLock = new object();
    
    public event SomeEventHandler SomeEvent
    {
        add
        {
            lock (someEventLock)
            {
                someEvent += value;
            }
        }
        remove
        {
            lock (someEventLock)
            {
                someEvent -= value;
            }
        }
    }
