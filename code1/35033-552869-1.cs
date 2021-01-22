    protected static void SetChildReferences(E parent)
    {
        foreach (var prop in typeof(E).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!prop.CanRead) continue;
            Type listType = null;
            foreach (Type type in prop.PropertyType.GetInterfaces())
            {
                if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    listType = type.GetGenericArguments()[0];
                    break;
                }
            }
            List<PropertyInfo> propsToSet = new List<PropertyInfo>();
            foreach (PropertyInfo childProp in 
                (listType ?? prop.PropertyType).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (childProp.PropertyType == typeof(E))
                    propsToSet.Add(childProp);
            }
            if (propsToSet.Count == 0) continue;
            if (listType == null)
            {
                object child = prop.GetValue(parent, null);
                if (child == null) continue;
                UpdateProperties(propsToSet, child, parent);
            }
            else
            {
                ICollection collection = (ICollection)prop.GetValue(parent, null);
                foreach (object child in collection)
                {
                    if (child == null) continue;
                    UpdateProperties(propsToSet, child, parent);
                }
            }
        }
    }
    protected static void UpdateProperties(List<PropertyInfo> properties, object target, object value)
    {
        foreach (PropertyInfo property in properties)
        {
            property.SetValue(target, value, null);
        }
    }
