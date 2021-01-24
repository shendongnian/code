    public string ToString( Process process) {
        var msg = new StringBuffer();
        foreach (PropertyInfo property in process.GetProperties()) {
             var propertyValue = new PropertyValue( property.Name, property.GetValue( process));
             msg.Append( ((msg.Length > 0)? ",": "") + propertyValue.ToString());
        }
        return msg.ToString();
    }
    public PropertyValue[] FromString( string msg) 
    {
        string[] pvStrings = msg.Split(",");
        PropertyValue[] propertyValues = new PropertyValue[pvStrings.Length];
        int i = 0;
        foreach (string pvString in pvStrings) {
            propertyValues[i] = FromString( pvString);
        }
        return propertyValues;
    } 
