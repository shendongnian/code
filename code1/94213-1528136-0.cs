    public static void OutputProperties(object obj)
    {
        if (obj == null) throw new ArgumentNullException("obj");
        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(obj))
        {
            object val = prop.GetValue(obj);
            string s = prop.Converter.ConvertToString(val);
            Console.WriteLine(prop.Name + ": " + s);
        }
    }
