    public static class Guard
        {
            public static void IsNotNull<T>(Expression<Func<T>> expr)
            {
                // expression value != default of T
                if (!expr.Compile()().Equals(default(T)))
                    return;
    
                var param = (MemberExpression) expr.Body;
                throw new ArgumentNullException(param.Member.Name);
            }
        }
