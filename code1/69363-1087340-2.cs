    public Hashtable GetPropertyInfo(Person person)
    {
        var properties = new Hashtable();
        PropertyInfo[] propInfo = person.GetType().GetProperties();
        foreach (PropertyInfo prop in propInfo)
        {
             properties.Add(prop.Name, prop.GetValue(person, null));
        }
        return properties;
    }
