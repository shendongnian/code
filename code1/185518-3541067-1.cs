    while (sqlReader.Read())
    {
        T item = new T();
        foreach (PropertyInfo property in type.GetProperties())
        {
            // Note the first parameter "item"
            property.SetValue(item, sqlReader[property.Name], null);
        }
        typeList.Add(item);
    }
