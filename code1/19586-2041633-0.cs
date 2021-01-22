    /// <summary>
    /// Provides the <see cref="nameof"/> extension method that works as a workarounds for a nameof() operator, 
    /// which should be added to C# sometime in the future.
    /// </summary>
    public static class NameOfHelper
    {
        /// <summary>
        /// Returns a string represantaion of a property name (or a method name), which is given using a lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="obj"/> parameter.</typeparam>
        /// <typeparam name="TProp">The type of the property (or the method's return type), which is used in the <paramref name="expression"/> parameter.</typeparam>
        /// <param name="obj">An object, that has the property (or method), which its name is returned.</param>
        /// <param name="expression">A Lambda expression of this pattern: x => x.Property <BR/>
        /// Where the x is the <paramref name="obj"/> and the Property is the property symbol of x.<BR/>
        /// (For a method, use: x => x.Method()</param>
        /// <returns>A string that has the name of the given property (or method).</returns>
        public static string nameof<T, TProp>(this T obj, Expression<Func<T, TProp>> expression)
        {
            MemberExpression memberExp = expression.Body as MemberExpression;
            if (memberExp != null)
                return memberExp.Member.Name;
            MethodCallExpression methodExp = expression.Body as MethodCallExpression;
            if (methodExp != null)
                return methodExp.Method.Name;
            throw new ArgumentException("'expression' should be a member expression or a method call expression.", "expression");
        }
        /// <summary>
        /// Returns a string represantaion of a property name (or a method name), which is given using a lambda expression.
        /// </summary>
        /// <typeparam name="TProp">The type of the property (or the method's return type), which is used in the <paramref name="expression"/> parameter.</typeparam>
        /// <param name="expression">A Lambda expression of this pattern: () => x.Property <BR/>
        /// Where Property is the property symbol of x.<BR/>
        /// (For a method, use: () => x.Method()</param>
        /// <returns>A string that has the name of the given property (or method).</returns>
        public static string nameof<TProp>(Expression<Func<TProp>> expression)
        {
            MemberExpression memberExp = expression.Body as MemberExpression;
            if (memberExp != null)
                return memberExp.Member.Name;
            MethodCallExpression methodExp = expression.Body as MethodCallExpression;
            if (methodExp != null)
                return methodExp.Method.Name;
            throw new ArgumentException("'expression' should be a member expression or a method call expression.", "expression");
        }
    }
