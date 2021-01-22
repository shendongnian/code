    public static List<String> DiffObjectsProperties(object a, object b)
    {
        Type type = a.GetType();
        List<String> differences = new List<String>();
        foreach (PropertyInfo p in type.GetProperties())
        {
            object aValue = p.GetValue(a, null);
            object bValue = p.GetValue(b, null);
    
            if (p.PropertyType.IsPrimitive || p.PropertyType == typeof(string))
            {
                if (!aValue.Equals(bValue))
                    differences.Add(
                        String.Format("{0}:{1}!={2}",p.Name, aValue, bValue)
                    );
            }
            else
                differences.AddRange(DiffObjectsProperties(aValue, bValue));
        }
    
        return differences;
    }
