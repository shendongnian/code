public static string GetPropertyName<TResult>(Expression<Func<TResult>> expr)
{
    var memberAccess = expr.Body as MemberExpression;
    var propertyInfo = memberAccess?.Member as PropertyInfo;
    var propertyName = propertyInfo?.Name;
    return propertyName;
}
