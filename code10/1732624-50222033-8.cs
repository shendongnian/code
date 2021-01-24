    TraverseProps(person);
    // ..................................................
    static void TraverseProps(object obj, int level = 0)
    {
        string indent = new string(' ', level * 2);
        if (obj == null)
        {
            Console.WriteLine(indent + "<NULL>");
            return;
        }
        var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            Console.Write(indent + property.Name + ": ");
            if (property.PropertyType.IsArray)
            {
                Console.WriteLine(indent + "[");
                int i = 0;
                foreach (var item in (Array)value)
                {
                    Console.WriteLine(indent + "item " + i + ":");
                    TraverseProps(item, level + 1);
                    i++;
                }
                Console.WriteLine(indent + "]");
            }
            else
            {
                Console.WriteLine(value);
            }
        }
    }
