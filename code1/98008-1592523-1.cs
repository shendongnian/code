    Type radioButtonType = rdb.GetType(); //or typeof(RadioButton)
    //get the internal property
    PropertyInfo uniqueGroupProperty = radioButtonType.GetProperty("UniqueGroupName",
        BindingFlags.Instance | BindingFlags.NonPublic);
    //get the value of the property on the current RadioButton object
    object propertyValue = uniqueGroupProperty.GetValue(rdb, null);
    //cast as string
    string uniqueGroupName = propertyValue as string;
