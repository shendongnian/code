    CustomEvent myEvent
    public delegate EventHandler MyEvent {
        add { myEvent = myEvent.Combine(value); }
        remove {myEvent = myEvent.Remove(value); }
    }
