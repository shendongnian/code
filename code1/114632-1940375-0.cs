    foreach(ClassProperties myProp in Enum.GetValues(typeof(ClassProperties)))
    {
        Test t = new Test();
        PropertyInfo prop = typeof(Test).GetProperty(myProp.ToString());
        // Get
        object value = prop.GetValue(t, null);
        // Set
        prop.SetValue(t, newValue, null);
    }
