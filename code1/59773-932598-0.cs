    public static IQueryable<TSource> SearchInText<TSource>(this IQueryable<TSource> source, string textToFind)
    {
        if (textToFind.Trim() == "")
        {
            return source;
        }
        string[] textToFindList = textToFind.Replace("'", "''").Split(' ');
        // Collect fields
        PropertyInfo[] propertiesInfo = source.ElementType.GetProperties();
        List<string> fieldList = new List<string>();
        foreach (PropertyInfo propertyInfo in propertiesInfo)
        {
            if (
                (propertyInfo.PropertyType == typeof(string)) ||
                (propertyInfo.PropertyType == typeof(int)) ||
                (propertyInfo.PropertyType == typeof(long)) ||
                (propertyInfo.PropertyType == typeof(byte)) ||
                (propertyInfo.PropertyType == typeof(short))
                )
            {
                fieldList.Add(propertyInfo.Name);
            }
        }
        ParameterExpression parameter = Expression.Parameter(typeof(TSource), source.ElementType.Name);
        MethodInfo concatMethod = typeof(String).GetMethod("Concat", new Type[] { typeof(string), typeof(string) });
        var spaceExpression = Expression.Constant(" ");
        var concatenatedField = BinaryExpression.Add(spaceExpression, Expression.MakeMemberAccess(parameter, typeof(TSource).GetProperty(fieldList[0])), concatMethod);
        
        for (int i = 1; i < fieldList.Count; i++)
        {
            concatenatedField = BinaryExpression.Add(concatenatedField, spaceExpression, concatMethod);
            concatenatedField = BinaryExpression.Add(concatenatedField, Expression.MakeMemberAccess(parameter, typeof(TSource).GetProperty(fieldList[i])), concatMethod);
        }
        concatenatedField = BinaryExpression.Add(concatenatedField, spaceExpression, concatMethod);
        var fieldsExpression = Expression.Call(concatenatedField, "ToUpper", null, null);
        var clauseExpression = Expression.Call(
            fieldsExpression, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }),
            Expression.Constant(textToFindList[0].ToUpper())
            );
        if (textToFindList.Length == 1)
        {
           return source.Where(Expression.Lambda<Func<TSource, bool>>(clauseExpression, parameter));
        }
        BinaryExpression expression = Expression.And(Expression.Call(
                fieldsExpression, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }),
                Expression.Constant(textToFindList[1].ToUpper())
                ), clauseExpression);
        for (int i = 2; i < textToFindList.Length; i++)
        {
            expression = Expression.And(Expression.Call(
                fieldsExpression, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }),
                Expression.Constant(textToFindList[i].ToUpper())
                ), expression);
        }
        
        return source.Where(Expression.Lambda<Func<TSource, bool>>(expression, parameter));
    }
