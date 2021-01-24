    using System.Linq.Expressions;
    public static DynamicConstructor<T> GetDynamicConstructor<T>()
    {
        ConstructorInfo originalCtor = typeof(T).GetConstructors().First();
        var parameter = Expression.Parameter(typeof(string[]), "args");
        var parameterExpressions = new List<Expression>();
        
        ParameterInfo[] paramsInfo = originalCtor.GetParameters();
        for (int i = 0; i < paramsInfo.Length; i++)
        {
            Type paramType = paramsInfo[i].ParameterType;
            Expression paramValue = Expression.ArrayIndex(parameter, Expression.Constant(i));
            if (paramType.IsEnum)
            {
                var enumParse = typeof(Enum).GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(Type), typeof(string) }, null);
                var call = Expression.Call(null, enumParse, new[] { Expression.Constant(paramType), paramValue });
                paramValue = Expression.Convert(call, paramType);
            }
            else if (paramType != typeof(string))
            {
                var parseMethod = paramType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(string) }, null);
                if (parseMethod == null)
                {
                    throw new Exception($"Cannot find Parse method for type {paramType} (parameter index:{i})");
                }
                
                paramValue = Expression.Call(null, parseMethod, new[] { paramValue });
            }            
            
            parameterExpressions.Add(paramValue);
        }
        var newExp = Expression.New(originalCtor, parameterExpressions);
        var lambda = Expression.Lambda<DynamicConstructor<T>>(newExp, parameter);
        return lambda.Compile();
    }
