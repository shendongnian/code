    public ReadOnlyCollection<SomeOtherClass> SomeOtherClassItems
    {
        get
        {
            return _SomeOtherClassItems.AsReadOnly();
        }
    }
