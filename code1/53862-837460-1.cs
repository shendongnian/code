    public EventHandler<EventArgs> SomeEvent;
    
    protected void OnSomeEvent(EventArgs args)
    {
        var handler = SomeEvent;
        if (handler != null)
        {
            foreach (EventHandler<EventArgs> item in handler.GetInvocationList())
            {
                try
                {
                    item(this, args);
                }
                catch (Exception e)
                {
                    // handle / report / ignore exception
                }
            }                
        }
    }
