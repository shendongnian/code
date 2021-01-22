    public void DoSomethingAsynchronously(EventHandler callBack)
    {
        // long running logic.
        callBack(this, EventArgs.Empty);
    }
