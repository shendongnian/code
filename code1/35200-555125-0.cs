    /// <summary>
    /// This is the Event Delegate
    /// </summary>
    public delegate void MyEventHandler(object sender, EventArgs e);
    /// <summary>
    /// This event is thrown when <...>
    /// </summary>
    public event MyEventHandler NewMyEvent;
    /// <summary>
    /// Internal event that triggers the external events
    /// </summary>
    /// <param name="e"></param>
    private void OnNewMyEvent(EventArgs e)
    {
        if (NewMyEvent != null)
            NewMyEvent(this, e);
    }
