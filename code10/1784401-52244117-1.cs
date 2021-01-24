    Test test = new Test();
    
    PropertyInfo[] properties = typeof(Test).GetProperties();
    foreach (var prop in properties)
    {
        if(prop.PropertyType == typeof(bool))
        {   
            prop.SetValue(test, true);
        }
    }
