    void Main()
    {
    	Console.WriteLine(CombineAllFlags<MyEnum>()); // Prints "Foo, Bar, Baz"
    }
    
    [Flags]
    public enum MyEnum
    {
        Foo = 1,
        Bar = 2,
        Baz = 4
    }
    
    public static TEnum CombineAllFlags<TEnum>()
    {
        TEnum[] values = (TEnum[])Enum.GetValues(typeof(TEnum));
        TEnum tmp = default(TEnum);
        foreach (TEnum v in values)
        {
            tmp = EnumHelper<TEnum>.Or(tmp, v);
        }
        return tmp;
    }
    
    static class EnumHelper<T>
    {
        private static Func<T, T, T> _orOperator = MakeOrOperator();
        
        private static Func<T, T, T> MakeOrOperator()
        {
            Type underlyingType = Enum.GetUnderlyingType(typeof(T));
            ParameterExpression xParam = Expression.Parameter(typeof(T), "x");
            ParameterExpression yParam = Expression.Parameter(typeof(T), "y");
            var expr =
                Expression.Lambda<Func<T, T, T>>(
                    Expression.Convert(
                        Expression.Or(
                            Expression.Convert(xParam, underlyingType),
                            Expression.Convert(yParam, underlyingType)),
                        typeof(T)),
                    xParam,
                    yParam);
            return expr.Compile();
        }
    
        public static T Or(T x, T y)
        {
            return _orOperator(x, y);
        }   
    }
