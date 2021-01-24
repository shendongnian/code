    private static string BatchItem_NFSerialization(INF Alldebtors)
    {
        Type t = Alldebtors.GetType();
        var extraTypes1 = GetKnownTypes(Alldebtors);
                            
        using (MemoryStream ms = new MemoryStream())
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(t, extraTypes1);
            serializer.WriteObject(ms, ((BatchItem_NF)Alldebtors));
    
            var retVal = Encoding.Default.GetString(ms.ToArray());
            return retVal;
        }
    }
    
    private static IEnumerable<Type> GetKnownTypes(object property)
    {
        Type t = property.GetType();
    
        var extraValues = t.GetProperties()
            .Where(p => p.PropertyType.IsInterface && !p.PropertyType.IsGenericType)
            .Select(p => p.GetValue(property, null))
            .ToArray();
    
        var extraTypes = extraValues.SelectMany(GetKnownTypes).ToArray();
    
        return extraValues.Select(v => v.GetType()).Concat(extraTypes).ToArray();
    }
