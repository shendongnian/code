    private EventHandler _someEvent; // notice the lack of the event keyword!
    public event EventHandler SomeEvent
    {
        add { _someEvent += value; }
        remove { _someEvent -= value; }
    }
