    //the event
    public event EventHandler SomethingHappened;
    
    protected virtual void OnSomethingHappened(EventArgs e)
    {
        //make sure we have someone subscribed to our event before we try to raise it
        if(this.SomethingHappened != null)
        {
            this.SomethingHappened(this, e);
        }
    }
    private void SomeMethod()
    {
        //call our method when we want to raise the event
        OnSomethingHappened(EventArgs.Empty);
    }
