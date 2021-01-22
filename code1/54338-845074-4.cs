    var param = Expression.Parameter(typeof(SomeType), "p");
    var body = Expression.AndAlso(
           Expression.Equal(
                Expression.PropertyOrField(param, "Length"),
                Expression.Constant(5)
           ),
           Expression.Equal(
                Expression.PropertyOrField(param, "SomeOtherProperty"),
                Expression.Constant("hello")
           ));
    var lambda = Expression.Lambda<Func<SomeType, bool>>(body, param);
