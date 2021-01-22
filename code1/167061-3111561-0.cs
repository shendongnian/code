    Type buffType = Output0Buffer.GetType();
    for(int i = 0; i < columns.Length; i++)
    {
        string propertyName = String.Format("Column{0}", i);
        PropertyInfo pi = buffType.GetProperty(propertyName);
        pi.SetValue(buffer, columns[i], null);
    }
