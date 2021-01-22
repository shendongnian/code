    EventHandler anEventDelegates
    public OtherClass Inner {
        get { /* ... */ }
        set {
            //...
            if(value != null)
                value.AnEvent += anEventDelegates;
            //...
        }
    }
    public event EventHandler AnEvent {
        add {
            anEventDelegates += value;
            if (Inner != null) Inner.AnEvent += value;
        }
        remove {
            anEventDelegates -= value;
            if(Inner != null) Inner -= value;
        }
    }
