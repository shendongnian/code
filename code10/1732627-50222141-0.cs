    if (property.PropertyType.IsArray)
    {
        foreach (var item in (Array) property.GetValue(person))
        {
            var props = item.GetType().GetProperties();
            foreach (var prop in props)
            {
                Console.WriteLine(prop.Name);
                Console.WriteLine(prop.GetValue(item));
            }
        }
    }
