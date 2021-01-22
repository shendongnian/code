    var type = typeof(MyObject);
    foreach (var field in type.GetFields(BindingFlags.Public |
                 BindingFlags.NonPublic | BindingFlags.Instance))
    {
        if (field.IsDefined(typeof(ObsoleteAttribute), true))
        {
            Console.WriteLine(field.Name);
        }
    
    }
