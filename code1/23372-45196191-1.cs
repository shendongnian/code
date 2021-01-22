    public static class Throw
    {
        public static void IfArgNull<T>(Expression<Func<T>> arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg), "There is no expression with which to test the object's value.");
            }
            // get the variable name of the argument
            MemberExpression metaData = arg.Body as MemberExpression;
            if (metaData == null)
            {
                throw new ArgumentException("Unable to retrieve the name of the object being tested.", nameof(arg));
            }
            // can the data type be null at all
            string argName = metaData.Member.Name;
            Type type = typeof(T);
            if (type.IsValueType && Nullable.GetUnderlyingType(type) == null)
            {
                throw new ArgumentException("The expression does not specify a nullible type.", argName);
            }
            // get the value and check for null
            if (arg.Compile()() == null)
            {
                throw new ArgumentNullException(argName);
            }
        }
    }
