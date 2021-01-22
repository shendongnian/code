    public event EventHandler MyEvent
    internal protected virtual void OnMyEvent() { OnMyEvent(EventArgs.Empty); }
    internal protected virtual void OnMyEvent(EventArgs e) {
        var handler = MyEvent;
        if (handler != null) handler(this, e);
    }
