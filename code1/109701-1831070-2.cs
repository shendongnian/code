    static void WriteTsv<T>(this IEnumerable<T> data, TextWriter output)
    {
        PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
        foreach (PropertyDescriptor prop in props)
        {
            output.Write(prop.DisplayName); // header
            output.Write("\t");
        }
        output.WriteLine();
        foreach (T item in data)
        {
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.Converter.ConvertToString(
                     prop.GetValue(item)));
                output.Write("\t");
            }
            output.WriteLine();
        }
    }
