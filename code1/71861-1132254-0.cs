    public EventHandler DiffEvent;
    public EventHandler AnotherDiffEvent;
    public event EventHandler SomeEvent
    {
        add
        {
            DiffEvent += value;
            AnotherDiffEvent += value;
        }
        remove
        {
            DiffEvent -= value;
            AnotherDiffEvent -= value;
        }
    }
