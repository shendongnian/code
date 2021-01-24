    public class Structure
    {
        public Parameter[] InputParams { get; set; }
        public Parameter OutputParam { get; set; }
        public Graph Expression { get; set; }
    }
    public class Parameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class Builder
    {
        public static Expression Build(Structure s)
        {
            var inputParams = new ParameterExpression[s.InputParams.Length];
            int index = 0;
            foreach (var param in s.InputParams)
            {
                inputParams[index++] = Expression.Parameter(GetDataType(param.Type), param.Name);
            }
            Type lambdaDefinition = GetLambdaTypeDefinition(s.InputParams.Length);
            Type[] typeArgs = s.InputParams.Select(p => GetDataType(p.Type)).Concat(new Type[] { GetDataType(s.OutputParam.Type) }).ToArray();
            Type lambdaType = lambdaDefinition.MakeGenericType(typeArgs);
            ParameterExpression delegVar = Expression.Variable(lambdaType, "sum");
            LambdaExpression expression = Expression.Lambda(
                Expression.Block(
                    new[] { delegVar },
                    Expression.Assign(delegVar,
                        Expression.Lambda(
                            Expression.Block(
                                // some work is done here
                                Expression.Invoke(delegVar, inputParams)
                            ),
                            inputParams
                        )
                    ),
                    Expression.Invoke(delegVar, inputParams)
                ),
                inputParams
            );
            return expression;
        }
        private static Type GetDataType(string type)
        {
            switch (type)
            {
                case DataTypes.Boolean:
                    return typeof(bool);
                case DataTypes.Number:
                    return typeof(double);
                case DataTypes.NumArray:
                    return typeof(double[]);
            }
            return null;
        }
        private static Type GetLambdaTypeDefinition(int inputLength)
        {
            switch (inputLength)
            {
                case 1:
                    return typeof(Func<,>);
                case 2:
                    return typeof(Func<,,>);
                case 3:
                    return typeof(Func<,,,>);
                case 4:
                    return typeof(Func<,,,,>);
                case 5:
                    return typeof(Func<,,,,,>);
                case 6:
                    return typeof(Func<,,,,,,>);
                case 7:
                    return typeof(Func<,,,,,,,>);
                case 8:
                    return typeof(Func<,,,,,,,,>);
                case 9:
                    return typeof(Func<,,,,,,,,,>);
                case 10:
                    return typeof(Func<,,,,,,,,,,>);
                case 11:
                    return typeof(Func<,,,,,,,,,,,>);
                case 12:
                    return typeof(Func<,,,,,,,,,,,,>);
                case 13:
                    return typeof(Func<,,,,,,,,,,,,,>);
                case 14:
                    return typeof(Func<,,,,,,,,,,,,,,>);
                case 15:
                    return typeof(Func<,,,,,,,,,,,,,,,>);
                case 16:
                    return typeof(Func<,,,,,,,,,,,,,,,,>);
                default:
                    throw new Exception("Too many input parameters");
            }
        }
    }
