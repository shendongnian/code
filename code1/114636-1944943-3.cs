    var obj = new TestClass();
    var allProps = typeof(TestClass).GetProperties();
    foreach (var prop in allProps)
    {
        // Get propertie value
        object propValue = prop.GetGetMethod().Invoke(obj, null);
        //Set propertie value
        prop.GetSetMethod().Invoke(obj, new object[] { propValue });
    }
