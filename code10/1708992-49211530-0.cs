    // <summary>
    // cached dynamic method to set a CLR property value on a CLR instance
    // </summary>
    internal Action<object, object> ValueSetter
    {
        get { return _memberSetter; }
        set
        {
            DebugCheck.NotNull(value);
            // It doesn't matter which delegate wins, but only one should be jitted
            Interlocked.CompareExchange(ref _memberSetter, value, null);
        }
    }
