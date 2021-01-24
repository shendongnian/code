    public event EventHandler MyEvent
    {
        add
        {
            lock (objectLock)
            {
                myEvent += value;
            }
        }
        remove
        {
            lock (objectLock)
            {
                myEvent -= value;
            }
        }
    }
