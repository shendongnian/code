    public delegate void EventDelegate();
    //dictionary of events supported by this class
    protected Dictionary<EventName, EventDelegate> events = new Dictionary<EventName, EventDelegate>();
    public void AddListener(EventName name, EventDelegate listener)
    {
        if (!events.ContainsKey(name))
        {
            events[name] = listener;
        }
        else
        {
            events[name] += listener;
        }
    }
    protected virtual void OnPickup(EventName name)
    {
        if (events.ContainsKey(name) && events[name] != null)
        {
            events[name]();
        }
    }
