    public event EventHandler<EventArgs> SomeEvent;
    protected virtual void OnSomeEvent()
    {
        if (this.SomeEvent !=null)
        {
            this.SomeEvent.Invoke(this,EventArgs.Empty);
        }
    }
