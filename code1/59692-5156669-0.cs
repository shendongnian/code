    MyType destination = new MyType();
    MyType source = new MyType();
    // Iterate the Properties of the destination instance and 
    // populate them from their source counterparts
    PropertyInfo[] destinationProperties = destination.GetType().GetProperties();
    foreach (PropertyInfo destinationPI in destinationProperties)
    {
        PropertyInfo sourcePI = source.GetType().GetProperty(destinationPI.Name);
                
        destinationPI.SetValue(destination,
                               sourcePI.GetValue(source, null), 
                               null);
    }
