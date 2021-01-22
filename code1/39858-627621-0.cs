    static class Argument
    {
        public static void NotNull(Expression<Func<Func<object>>> arg)
        {
            if (arg.Compile()()() == null)
            {
                var body1 = (Expression<Func<object>>)arg.Body;
                var body2 = (MemberExpression)body1.Body;
                throw new ArgumentNullException(body2.Member.Name);
            }
        }
    }
