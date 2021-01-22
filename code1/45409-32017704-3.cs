     public Truck() {
        PropertyInfo[] properties = type.GetProperties();
        for (int i = 0; i < properties.Length; ++i)
        {
        	if (!_ignorePropertiesToReset.Contains(properties[i].Name))  //exclude properties you don't want to reset
        		_propertyValues.Add(properties[i].Name, properties[i].GetValue(this));
        }
    }
