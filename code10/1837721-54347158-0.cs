    foreach (object objl_THIS in lstl_OBJ)
    {
        var type = objl_THIS.GetType();
        var propertyInfos = type.GetProperties();
        foreach(var propertyInfo in propertyInfos)
        {
            string name = propertyInfo.Name;
            object value = propertyInfo.GetValue(objl_THIS); // <-- value
        }
    }
