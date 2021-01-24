    Type type = item.GetType();
    PropertyInfo[] properties = type.GetProperties();
    foreach (PropertyInfo property in properties)
    {
        Console.WriteLine(property.GetValue(item));
        if ( property.GetValue(item).ToString().Contains(";") )
        {
            error.Append(property.Name + " may not contain a ';'.");
        }
    }
