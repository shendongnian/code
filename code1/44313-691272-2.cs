    public static class ConsoleHelper
    {
        public static PropertyWriter WriteProperty<T>(Expression<Func<T>> expr)
            {
                var param = (MemberExpression)expr.Body;
                Console.WriteLine("Property [" + param.Member.Name + "] = " + expr.Compile()());
                return null;
            }
        
            public static PropertyWriter And<T>(this PropertyWriter ignored, Expression<Func<T>> expr)
            {
                ConsoleHelper.WritePropertyToConsole(expr);
                return null;
            }
    }
