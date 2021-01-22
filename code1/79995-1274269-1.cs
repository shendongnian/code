    public static IEnumerable<T> Read<T>(IDataReader reader) where T : class, new() 
    {
        PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
        PropertyDescriptor[] propArray = new PropertyDescriptor[reader.FieldCount];
        for (int i = 0; i < propArray.Length; i++)
        {
            propArray[i] = props[reader.GetName(i)];
        }
        while(reader.Read()) {
            T item = new T();
            for (int i = 0; i < propArray.Length; i++)
            {
                object value = reader.IsDBNull(i) ? null : reader[i];
                propArray[i].SetValue(item, value);
            }
            yield return item;
        }
    }
