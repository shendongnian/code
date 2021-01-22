     public Truck() {
        PropertyInfo[] properties = type.GetProperties();
        //exclude properties you don't want to reset, put the rest in the dictionary
        for (int i = 0; i < properties.Length; ++i){
        	if (!_ignorePropertiesToReset.Contains(properties[i].Name))  
        		_propertyValues.Add(properties[i].Name, properties[i].GetValue(this));
        }
    }
