    public static String[] GetCommonPropertiesByName(Object[] objs)
    {
        List<Type> typeList = new List<Type>(Type.GetTypeArray(objs));
        List<String> propertyList = new List<String>();
        List<String> individualPropertyList = new List<String>();
    
        foreach (Type type in typeList)
        {
            foreach (PropertyInfo property in type.GetProperties())
            {
                propertyList.Add(property.Name);
            }
        }
    
        propertyList = propertyList.Distinct().ToList();
    
        foreach (Type type in typeList)
        {
            individualPropertyList.Clear();
            foreach (PropertyInfo property in type.GetProperties())
            {
                individualPropertyList.Add(property.Name);
            }
            propertyList = propertyList.Intersect(individualPropertyList).ToList();
        }
        
        return propertyList.ToArray();
    }
