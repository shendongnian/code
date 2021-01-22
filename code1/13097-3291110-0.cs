    //get the data from the object factory
    object[] newDataArray = AppObjectFactory.BuildInstances(Type.GetType("OutputData"));
    if (newDataArray != null)
    {
        SomeComplexObject result = new SomeComplexObject();
        //find the source
        Type resultTypeRef = result.GetType();
        //get a reference to the property
        PropertyInfo pi = resultTypeRef.GetProperty("TargetPropertyName");
        if (pi != null)
        {
            //create an array of the correct type with the correct number of items
            pi.SetValue(result, Array.CreateInstance(Type.GetType("OutputData"), newDataArray.Length), null);
            //copy the data and leverage Array.Copy's built in type casting
            Array.Copy(newDataArray, pi.GetValue(result, null) as Array, newDataArray.Length);
        }
    }
