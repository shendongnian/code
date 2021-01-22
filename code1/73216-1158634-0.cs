    public static void ArgumentNotNull(object argument, string parameterName)
    {
        if (parameterName == null)
            throw new ArgumentNullException("parameterName");
        if (argument == null)
            throw new ArgumentNullException(parameterName);
    }
