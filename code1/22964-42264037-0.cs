    void DumpObject(object obj, int nestingLevel = 0)
    {
        var nestingSpaces = "".PadLeft(nestingLevel * 4);
        if (obj == null)
        {
            Console.WriteLine("{0}null", nestingSpaces);
        }
        else if (obj is string || obj.GetType().IsPrimitive)
        {
            Console.WriteLine("{0}{1}", nestingSpaces, obj);
        }
        else if (obj is IDictionary)
        {
            foreach (dynamic p in obj as IDictionary)
            {
                Console.WriteLine("{0}{1} ({2})", nestingSpaces, p.Key, p.Value != null ? p.Value.GetType() : "<null>");
                DumpObject(p.Value, nestingLevel + 1);
            }
        }
        else if (obj is IEnumerable)
        {
            foreach (dynamic p in obj as IEnumerable)
            {
                DumpObject(p, nestingLevel);
            }
        }
        else
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                Console.WriteLine("{0}{1}={2}", nestingSpaces, name, value);
            }
        }
    }
