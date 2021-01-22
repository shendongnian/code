    ///<summary>Validates method parameters</summary>
    ///... rest of documentation
    public void CheckParameters(string methodName, List<Object> parameterValues) 
    {
        if ( string.IsNullOrEmpty(methodName) )
           throw new ArgumentException("Fire the programmer! Missing method name", "methodName"));
        Type t = typeof(MyClass);
        MethodInfo method = t.GetMethod(methodName);
        if ( method == null )
           throw new ArgumentException("Fire the programmer! Wrong method name", "methodName"));
        List<ParameterInfo> params = method.GetParameters();
        if ( params == null || params.Count != parameterValues.Count )
           throw new ArgumentException("Fire the programmer! Wrong list of parameters. Should have " + params.Count + " parameters", "parameterValues"));
        for (int i = 0; i < params.Count; i++ )
        {
                ParamInfo param = params[i];
                if ( param.Type != typeof(parameterValues[i]) )
                    throw new ArgumentException("Fire the programmer! Wrong order of parameters. Error in param " + param.Name, "parameterValues"));
                if ( parameterValues[i] == null )
                    throw new ArgumentException(param.Name + " cannot be null");
        }
    } // enjoy
