    Type type = obj.GetType(); //obj is your Rooster object
    PropertyInfo[] properties = type.GetProperties();
    
    foreach (PropertyInfo property in properties)
    {
        Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(obj, null));
    }
