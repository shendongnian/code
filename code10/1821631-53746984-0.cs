    var parentProperties = p.GetType().GetProperties();
    foreach (var property in parentProperties)
    {    
        var child = property.GetValue(p);
        var stringProperties = child.GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(string));
 
        // etc
    }
