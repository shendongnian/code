    PropertyInf[] propertiesInfo = MyObject.GetType().GetProperties();
    foreach(PropertyInf item in propertiesInfo)
    {
        if(requiredFields.Contains(item.Name))
            {
                //Do your operation here
            }
    }
