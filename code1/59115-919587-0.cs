    private string _myProperty = "TEST";
    public string MyProperty
    {
        get
        {
            return _myProperty;
        }
    }
    
    public string GetName(object value)
    {
        PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        for (int i = 0; i < properties.Length; i++)
        {
            object propValue = properties[i].GetValue(this, null);
            if (object.ReferenceEquals(propValue,value))
            {
                return properties[i].Name;
            }
        }
    
        return null;
    }
    Console.WriteLine(GetName(this.MyProperty)); // outputs "MyProperty"
