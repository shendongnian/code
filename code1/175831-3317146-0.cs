    public event EventHandler SomethingHappened;
    
    private void OnSomethingHappened()
    {
        SomethingHappened();
    }
