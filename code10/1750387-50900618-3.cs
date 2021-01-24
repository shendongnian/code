        public static DynamicConstructor GetDynamicConstructor(Type type)
        {
            ConstructorInfo originalCtor = type.GetConstructors().First();
            var parameter = Expression.Parameter(typeof(string[]), "args");
            var parameterExpressions = new List<Expression>();
            ParameterInfo[] paramsInfo = originalCtor.GetParameters();
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Type paramType = paramsInfo[i].ParameterType;
                // added check for default value on the parameter info.
                Expression defaultValueExp;
                if (paramsInfo[i].HasDefaultValue)
                {
                    defaultValueExp = Expression.Constant(paramsInfo[i].DefaultValue);
                }
                else
                {
                    // if there is no default value, then just provide 
                    // the type's default value, but we could potentially 
                    // do something else here
                    defaultValueExp = Expression.Default(paramType);
                }
                Expression paramValue;
               
                paramValue = Expression.ArrayIndex(parameter, Expression.Constant(i));
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
                // here we bounds check the array and emit a conditional expression
                // that will provide a default value if necessary. Equivalent to 
                // something like i < args.Length ? int.Parse(args[i]) : default(int);  
                // Of course if the parameter has a default value that is used instead, 
                // and if the target type is different (long, boolean, etc) then
                // we use a different parse method.
                Expression boundsCheck = Expression.LessThan(Expression.Constant(i), Expression.ArrayLength(parameter));
                paramValue = Expression.Condition(boundsCheck, paramValue, defaultValueExp);
                parameterExpressions.Add(paramValue);
            }
            var newExp = Expression.New(originalCtor, parameterExpressions);
            var lambda = Expression.Lambda<DynamicConstructor>(newExp, parameter);
            return lambda.Compile();
        }
    }
