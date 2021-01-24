    public string some_column_name
    {
        get
        {
            // current method name ("some_column_name") will be passed 
            // as "column" parameter
            return (string)GetValue();
        }
        set
        {
            // same here
            SetValue(value);
        }
    }
