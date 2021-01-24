    public static Dictionary<FieldInfo,object> ReadStaticFields(params Type[] types)
    {
        return types
            .SelectMany
            (
                t => t.GetFields(BindingFlags.Public | BindingFlags.Static)
            )
            .ToDictionary(f => f, f => f.GetValue(null) );
    }
