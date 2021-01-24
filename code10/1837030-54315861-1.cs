    UserKycCompositeModel newObj = new UserKycCompositeModel();
    
    foreach (var item in yourObject.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly))
    {
        propertyValue = item.GetValue(yourObject, null);
    	Type myType = typeof(newObj);                   
        PropertyInfo myPropInfo = myType.GetProperty(item.Name);
        myPropInfo.SetValue(this, value, null);
    }
