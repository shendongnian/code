    ArrayList delegates = new ArrayList();
    
    private event EventHandler MyRealEvent;
    
    public event EventHandler MyEvent
    {
        add
        {
            MyRealEvent += value;
            delegates.Add(value);
        }
    
        remove
        {
            MyRealEvent -= value;
            delegates.Remove(value);
        }
    }
    
    public void RemoveAllEvents()
    {
        foreach(EventHandler eh in delegates)
        {
            MyRealEvent -= eh;
        }
        delegates.Clear();
    }
