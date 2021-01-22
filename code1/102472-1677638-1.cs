    public object[] Something<T>(T[] items)
    {
        //get the properties on which are strings
        PropertyInfo[] properties = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string));
        IList objList = new List<string>;
        foreach(T item in items)
        {
            foreach(PropertyInfo property in properties)
            {
                objList.Add(property.GetValue(item, null) as string);
            }
        }
       }
       return objList.ToArray();
    }
