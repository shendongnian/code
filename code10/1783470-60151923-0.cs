cs
public static Expression<Func<T, bool>> Like<T>(Expression<Func<T, string>> prop, string keyword)
{
    var concatMethod = typeof(string).GetMethod(nameof(string.Concat), new[] { typeof(string), typeof(string) });
    return Expression.Lambda<Func<T, bool>>(
        Expression.Call(
            typeof(DbFunctionsExtensions),
            nameof(DbFunctionsExtensions.Like),
            null,
            Expression.Constant(EF.Functions),
            prop.Body,
            Expression.Add(
                Expression.Add(
                    Expression.Constant("%"),
                    Expression.Constant(keyword),
                    concatMethod),
                Expression.Constant("%"),
                concatMethod)),
        prop.Parameters);
}
query = query.Where(Like<User>(u => u.UserName, "angel"));
