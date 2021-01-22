    // If we have a ctor that requires parameters then pass null values
    if (requiresParameters)
    {
        List<object> parameters = new List<object>();
        ParameterInfo[] pInfos = constructorInfos[0].GetParameters();
    
        foreach (ParameterInfo pi in pInfos)
        {
            parameters.Add(createType(pi.ParameterType));
        }
    
        return constructorInfos[0].Invoke(parameters.ToArray());
    }
