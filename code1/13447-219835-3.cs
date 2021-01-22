    private Bar wrappedObject; // via ctor
    public event EventHandler SomeEvent
    {
        add { wrappedObject.SomeOtherEvent += value; }
        remove { wrappedObject.SomeOtherEvent -= value; }
    }
