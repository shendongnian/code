    private HashSet<EventHandler> _pausedHandlers = new HashSet<EventHandler>();
    public event EventHandler Paused
    {
        add // will not add duplicates
        { _pausedHandlers.Add(value); }
        remove
        { _pausedHandlers.Remove(value); }
    }
