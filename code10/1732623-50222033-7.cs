    if (property.PropertyType.IsArray)
    {
        foreach (var item in (Array)property.GetValue(person))
        {
            var subProperties = item.GetType().GetProperties();
            foreach (var subProperty in subProperties)
            {
                Console.WriteLine(subProperty.Name);
                Console.WriteLine(subProperty.GetValue(item));
            }
        }
    }
