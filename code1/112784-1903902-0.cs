    public event SomeDelegate MyEvent;
    private void FireMyEvent(MyEventArgs args)
    {
        var deleg = MyEvent;
        if (deleg != null) deleg(args);
    }
