    public object[] Something<T>(T[] items)
    {
        IList objList = new List<object>();
        //get the properties on which are strings
        PropertyInfo[] properties = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string));
        foreach(T item in items)
        {
            IList stringList = new List<string>;
            foreach(PropertyInfo property in properties)
            {
                objList.Add(property.GetValue(item, null) as string);
            }
            objList.Add(stringList);
        }
       }
       return objList.ToArray();
    }
