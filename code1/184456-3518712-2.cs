    private HashSet<EventHandler> pausedHandlers = new HashSet<EventHandler>();
    private EventHandler _paused;
    
    public event EventHandler Paused
    {
        add
        {
            if (pausedHandlers.Add(value))
            {
                _paused += value;
            }
        }
        remove
        {
            if (pausedHandlers.Remove(value))
            {
                _paused -= value;
            }
        }
    }
