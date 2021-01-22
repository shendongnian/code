    public void DoSomething()
    {
        var handler = SomethingHappened;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
