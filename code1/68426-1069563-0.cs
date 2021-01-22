    private EventHandler _myEvent;
    public event EventHandler MyEvent
    {
        add { _myEvent += value; }
        remove { _myEvent -= value; }
    }
