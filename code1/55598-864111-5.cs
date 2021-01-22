    bool PropValueOutOfRange(int val) {
        return val < kPropMin || val > kPropMax;
    }
    public int Prop {
        set {
            if (PropValueOutOfRange(value))
                throw new ArgumentOutOfRangeException("value");
            if (PropValueConflictsWithInternalState(value))
                throw new ArgumentException("value");
            _prop = value;
            NotifyPeriperalOfPropChange(_prop);
            FirePropChangedEvent(/* whatever args might be needed */);
        }
    }
