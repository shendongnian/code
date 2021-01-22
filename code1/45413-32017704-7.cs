    public void Reset() {
        PropertyInfo[] properties = type.GetProperties();
        for (int i = 0; i < properties.Length; ++i){
            //if dictionary has property name, use it to set the property
        	properties[i].SetValue(this, _propertyValues.ContainsKey(properties[i].Name) ? _propertyValues[properties[i].Name] : null);    	
        }
    }
