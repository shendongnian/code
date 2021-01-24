    var keyType = new { Prop1=default(string), Prop2=default(string) }.GetType();
    var ctor = keyType.GetConstructor(new Type[] { typeof(string), typeof(string) });
    var param = Expression.Parameter(typeof(GraphData), "x");
    var keySelector = Expression.Lambda(
        Expression.New(ctor,
            Expression.PropertyOrField(param, "Prop1"), // corresponds to Prop1
            Expression.PropertyOrField(param, "Prop2")  // corresponds to Prop2
        ),
        param
    ); // returns non-generic LambdaExpression
