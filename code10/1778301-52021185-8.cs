    private static Func<TOriginal, object> CreateNewStatementFor<TOriginal>(ISet<string> fields)
    {
        // input parameter "o"
        var xParameter = Expression.Parameter(typeof(TOriginal), "o");
        var propertyInfos = fields
            .Select(propertyName => typeof(TOriginal).GetProperty(propertyName))
            .ToArray();
        var anonymousType = CreateAnonymousType(propertyInfos);
        // create initializers
        var bindings = propertyInfos
            .Select(mi =>
            {
                // mi == property "Field1"
                // original value "o.Field1"
                var xOriginal = Expression.Property(xParameter, mi);
                // set value "Field1 = o.Field1"
                var mo = anonymousType.GetField(mi.Name);
                return Expression.Bind(mo, xOriginal);
            })
            .ToArray();
        // new statement "new Data()"
        var xNew = Expression.New(anonymousType);
        // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
        var xInit = Expression.MemberInit(xNew, bindings);
        // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
        var lambda = Expression.Lambda<Func<TOriginal, object>>(xInit, xParameter);
        //LambdaExpression.
        // compile to Func<Data, Data>
        return lambda.Compile();
    }
