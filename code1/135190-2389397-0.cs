    [NonSerialized]
    EventType backingField;
    public event EventType {
        add { backingField += value; }
        remove { backingField -= value; }
    }
