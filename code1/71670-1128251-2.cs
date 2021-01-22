    public static String GetPropertyNameFromLambdaExpression<TObject, TProperty>(
        Expression<Func<TObject, TProperty>> expression)
    {
        return ((MemberExpression)expression.Body).Member.Name;
    }
