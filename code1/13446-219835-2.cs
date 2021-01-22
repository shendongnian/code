    // only one instance field no matter how many events;
    // very useful if we expect most events to be unsubscribed
    private EventHandlerList events = new EventHandlerList();
    protected EventHandlerList Events {
        get { return events; } // usually lazy
    }
    // this code repeated per event
    private static readonly object FooEvent = new object();
    public event EventHandler Foo
    {
        add { Events.AddHandler(FooEvent, value); }
        remove { Events.RemoveHandler(FooEvent, value); }
    }
    protected virtual void OnFoo()
    {
        EventHandler handler = Events[FooEvent] as EventHandler;
        if (handler != null) handler(this, EventArgs.Empty);
    }
