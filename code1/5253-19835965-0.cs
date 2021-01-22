    public static class Utility
    {
        public static Tuple<string, TSource> GetNameAndValue<TSource>(Expression<Func<TSource>> sourceExpression)
        {
            Tuple<String, TSource> result = null;
            Type type = typeof (TSource);
            Func<MemberExpression, Tuple<String, TSource>> process = delegate(MemberExpression memberExpression)
                                                                        {
                                                                            ConstantExpression constantExpression = (ConstantExpression)memberExpression.Expression;
                                                                            var name = memberExpression.Member.Name;
                                                                            var value = ((FieldInfo)memberExpression.Member).GetValue(constantExpression.Value);
                                                                            return new Tuple<string, TSource>(name, (TSource) value);
                                                                        };
            Expression exception = sourceExpression.Body;
            if (exception is MemberExpression)
            {
                result = process((MemberExpression)sourceExpression.Body);
            }
            else if (exception is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)sourceExpression.Body;
                result = process((MemberExpression)unaryExpression.Operand);
            }
            else
            {
                throw new Exception("Expression type unknown.");
            }
            return result;
        }
    }
