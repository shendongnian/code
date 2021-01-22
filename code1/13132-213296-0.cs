    public string UserDefinedField
    {
        get { return InternalUserDefinedField; }
        set { InternalUserDefinedField = value; ChangedFields.Add(Fields.UserDefinedField); }
    }
    internal string InternalUserDefinedField 
    {
        get { return _userDefinedField; }
        set { _userDefinedField= value;  }
    }
