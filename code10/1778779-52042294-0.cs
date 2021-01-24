    expr = Expression.Call(
        typeof(NpgsqlDbFunctionsExtensions), 
        nameof(NpgsqlDbFunctionsExtensions.ILike),
        Type.EmptyTypes,
        Expression.Property(null, typeof(EF), nameof(EF.Functions)),
        property,
        Expression.Constant(search)
    );
