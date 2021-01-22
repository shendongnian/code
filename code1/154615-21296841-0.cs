    public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
    {
        MemberExpression me = propertyLambda.Body as MemberExpression;
        if (me == null)
        {
            throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
        }
        string result = string.Empty;
        do
        {
            result = me.Member.Name + "." + result;
            me = me.Expression as MemberExpression;
        } while (me != null);
        result = result.Remove(result.Length - 1); // remove the trailing "."
        return result;
    }
