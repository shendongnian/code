    private HashSet<EventHandler> pausedHandlers = new HashSet<EventHandler>();
    
    public event EventHandler Paused
    {
        add
        {
            if (pausedHandlers.Add(value))
            {
                Paused += value;
            }
        }
        remove
        {
            if (pausedHandlers.Remove(value))
            {
                Paused -= value;
            }
        }
    }
