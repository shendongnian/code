    [MethodImpl(MethodImplOptions.Synchronized)]
    public void add_MyEvent(EventHandler value)
    {
      this.MyEvent = (EventHandler) Delegate.Combine(this.MyEvent, value);
    }
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void remove_MyEvent(EventHandler value)
    {
        this.MyEvent = (EventHandler) Delegate.Remove(this.MyEvent, value);
    }
