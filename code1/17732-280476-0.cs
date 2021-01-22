    public string Error
    {
        get
        {
            return this["Name"] ?? this["Address"] ?? this["Phone"];
        }
    }
    public string this[string columnName]
    {
        get { ... }
    }
