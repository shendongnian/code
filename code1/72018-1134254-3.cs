    CustomEvent myEvent
    public event EventHandler MyEvent {
        add { myEvent = myEvent.Combine(value); }
        remove {myEvent = myEvent.Remove(value); }
    }
