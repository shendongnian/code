    public static object Convert<TObject, TTo>(TObject obj)
    {
        IEnumerable<MethodInfo> implicitConversionOperators = obj.GetType()
                                                                 .GetMethods()
                                                                 .Where(mi => mi.Name == "op_Implicit");
        MethodInfo fittingImplicitConversionOperator = null;
        foreach (MethodInfo methodInfo in implicitConversionOperators)
        {
            if (methodInfo.GetParameters().Any(parameter => parameter.ParameterType == typeof(TObject)))
            {
                fittingImplicitConversionOperator = methodInfo;
            }
        }
        if (fittingImplicitConversionOperator != null)
        {
            return fittingImplicitConversionOperator.Invoke(null, new object[] {obj});
        }
        return (TTo) System.Convert.ChangeType(obj, typeof(TTo));
    }
