    override public object this[string name] {
        get {
            return GetValue(GetOrdinal(name));
        }
    }
