    static Expression CallAny(Expression collection, Expression predicateExpression)
    {
        Type cType = GetIEnumerableImpl(collection.Type);
        collection = Expression.Convert(collection, cType); // (see "NOTE" below)
        Type elemType = cType.GetGenericArguments()[0];
        Type predType = typeof(Func<,>).MakeGenericType(elemType, typeof(bool));
        // Enumerable.Any<T>(IEnumerable<T>, Func<T,bool>)
        MethodInfo anyMethod = (MethodInfo)
            GetGenericMethod(typeof(Enumerable), "Any", new[] { elemType }, 
                new[] { cType, predType }, BindingFlags.Static);
        return Expression.Call(
            anyMethod,
            collection,
            predicateExpression);
    }
