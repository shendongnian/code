    var xParameter = Expression.Parameter(typeof(Entity1), "x");
    
    var pParameter = Expression.Parameter(typeof(Entity2), "p");
    
    var anyMethod =
        typeof(Enumerable)
            .GetMethods()
            .Single(x => x.Name == "Any" && x.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(Entity2));
    
    var anyCondition = Expression.Lambda<Func<Entity2, bool>>(
        Expression.Equal(
            Expression.Property(
                pParameter,
                typeof(Entity2).GetProperty("myprop").GetMethod),
            Expression.Constant(1, typeof(int))),
        pParameter);
    
    var query = context.MyTable.Where(
        Expression.Lambda<Func<Entity1, bool>>(
            Expression.Call(
                null,
                anyMethod,
                new Expression[] {
                    Expression.Property(
                        xParameter,
                        typeof(Entity1).GetProperty("mycollectionproperties").GetMethod),
                    anyCondition
                }),
            xParameter));
