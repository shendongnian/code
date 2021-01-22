    public string MyProperty
    {
        get { return _myField; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _myField = value;
            }
        }
    }
