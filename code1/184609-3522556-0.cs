    public void add_MyEvent(EventHandler value)
    {
        EventHandler handler2;
        EventHandler myEvent = this.MyEvent;
        do
        {
            handler2 = myEvent;
            EventHandler handler3 = (EventHandler) Delegate.Combine(handler2, value);
            myEvent = Interlocked.CompareExchange<EventHandler>(ref this.MyEvent, handler3, handler2);
        }
        while (myEvent != handler2);
    }
