    public IEnumerable<FieldInfo> FilterBackingEventFields(Type type)
    {
        List<int> backingFieldsTokens = type
            .GetEvents().Select(eventInfo => MetadataToken(eventInfo)).ToList();
    
        FieldInfo[] fieldInfos = type
            .GetFields(BindingFlags.NonPublic | 
                       BindingFlags.Public | 
                       BindingFlags.Instance);
    
        return fieldInfos
         .Where(fieldInfo => !backingFieldsTokens.Contains(fieldInfo.MetadataToken));
    }
    
    private static int MetadataToken(EventInfo eventInfo)
    {
        MethodInfo adderMethod = eventInfo.GetAddMethod();
        int fieldToken =
            adderMethod.GetMethodBody().GetILAsByteArray()[3] |
            adderMethod.GetMethodBody().GetILAsByteArray()[4] << 8 |
            adderMethod.GetMethodBody().GetILAsByteArray()[5] << 16 |
            adderMethod.GetMethodBody().GetILAsByteArray()[6] << 24;
    
        return fieldToken;
    }
