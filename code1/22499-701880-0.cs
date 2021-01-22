    public static Type GetCommonBaseClass (params Type[] types)
    {
        if (types.Length == 0)
            return typeof(object);
    
        Type ret = types[0];
    
        for (int i = 1; i < types.Length; ++i)
        {
            if (types[i].IsAssignableFrom(ret))
                ret = types[i];
            else
            {
                // This will always terminate when ret == typeof(object)
                while (!ret.IsAssignableFrom(types[i]))
                    ret = ret.BaseType;
            }
        }
    
        return ret;
    }
