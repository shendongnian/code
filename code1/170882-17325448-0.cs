    string csv = "";
    //get property names from the first object using reflection    
    IEnumerable<PropertyInfo> props = entityObjects.First().GetType().GetProperties();
    
    //header 
    csv += String.Join(", ",props.Select(prop => prop.Name)) + "\r\n";
    
    //rows
    foreach(var entityObject in entityObjects) 
    { 
        csv += String.Join(", ", props.Select(
            prop => ( prop.GetValue(entityObject, null) ?? "" ).ToString() 
        ) )
        + "\r\n";
    }
