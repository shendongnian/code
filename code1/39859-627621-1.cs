        public static void NotNull(object value, Expression<Func<Func<object>>> arg)
        {
            if (value == null)
            {
                var body1 = (Expression<Func<object>>)arg.Body;
                var body2 = (MemberExpression)body1.Body;
                throw new ArgumentNullException(body2.Member.Name);
            }
        }
