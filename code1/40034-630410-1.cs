        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(obj))
        {
            Console.WriteLine("{0}={1}",
                prop.Name, prop.Converter.ConvertToInvariantString(
                    prop.GetValue(obj)));
        }
