    public event EventHandler<EventArgs> SomeEvent;
    protected virtual void OnSomeEvent()
    {
        if (this.SomeEvent !=null)
        {
            this.someEvent.Invoke(this,EventArgs.Empty);
        }
    }
