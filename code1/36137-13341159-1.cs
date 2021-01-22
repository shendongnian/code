    public Type NameResourceType
    {
        get
        {
            return _resourceType;
        }
        set
        {
            _resourceType = value;
    
            _nameProperty = _resourceType.GetProperty(base.Description, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }
    }
