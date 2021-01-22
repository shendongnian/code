    protected Dictionaty<string, ComplexType> _properties = new Dictionaty<string, ComplexType>();
    public ComplexType Property(string name)
    {
        get
        {
            if (!properties.ContainsKey(name))
                _properties[name] = new ComplexType();
    
            return __properties[name];
        }
    }
