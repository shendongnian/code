    public string SomeProperty
    {
        get { return GetValue( () => SomeProperty ); }
        set { SetValue( () => SomeProperty, value ); }
    }
