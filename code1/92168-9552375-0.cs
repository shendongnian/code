    /* 
    example: Session.Query.Where(m => m.Regions.Where(f => f.Name.Equals("test")))
    */ 
    
    var innerItem = Expression.Parameter(typeof(MyInnerClass), "f");
    var innerProperty = Expression.Property(innerItem, "Name");
    var innerMethod = typeof(string).GetMethod("Equals", new[] { typeof(string) });
    var innerSearchExpression = Expression.Constant(searchString, typeof(string));
    var innerMethodExpression = Expression.Call(innerProperty, innerMethod, new[] { innerSearchExpression });
    var innerLambda = Expression.Lambda<Func<MyInnerClass, bool>>(innerMethodExpression, innerItem);
    
    var outerItem = Expression.Parameter(typeof(MyOuterClass), "m");
    var outerProperty = Expression.Property(outerItem, info.Name);
    /* calling a method extension defined in Enumerable */
    var outerMethodExpression = Expression.Call(typeof(Enumerable), "Where", new[] { typeof(MyInnerClass) }, outerProperty, innerLambda);
    var outerLambda = Expression.Lambda<Func<MyOuterClass, bool>>(outerMethodExpression, outerItem);
    query = query.Where(outerLambda);
