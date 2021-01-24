    foreach (var v in test.GetType().GetProperties())
    {
        var propertyValue = v.GetValue(test);
        foreach (var p in propertyValue.GetType().GetProperties())
        {
            var subPropertyValue = p.GetValue(propertyValue);
            Console.WriteLine("{0} = {1}", p.Name, subPropertyValue);
        }
    }
