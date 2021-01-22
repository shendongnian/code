    public string UserDefinedField
    {
        get { return _userDefinedField; }
        set { SetField(value); ChangedFields.Add(Fields.UserDefinedField); }
    }
    
    // Call this from internal methods and use the public property for other cases
    internal string SetField(string userValue)
    {
        _userDefinedField = userValue;
    }
