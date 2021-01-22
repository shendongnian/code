    public EventHandler GetHandler()
    {
        return new EventHandler(HandleEvent);
    }
    protected void HandleEvent(object sender, EventArgs args)
    {
    }
