    public static IQueryable<ReturnType> OfOnlyType<ReturnType, QueryType>
            (this IQueryable<QueryType> query)
            where ReturnType : QueryType {
        // Look just for immediate subclasses as that will be enough to remove
        // any generations below
        var subTypes = typeof(ReturnType).Assembly.GetTypes()
             .Where(t => t.IsSubclassOf(typeof(ReturnType)));
        if (subTypes.Count() == 0) { return query.OfType<ReturnType>(); }
        // Start with a parameter of the type of the query
        var parameter = Expression.Parameter(typeof(ReturnType));
        // Build up an expression excluding all the sub-types
        Expression removeAllSubTypes = null;
        foreach (var subType in subTypes) {
            // For each sub-type, add a clause to make sure that the parameter is
            // not of this type
            var removeThisSubType = Expression.Not(Expression
                 .TypeIs(parameter, subType));
            // Merge with the previous expressions
            if (removeAllSubTypes == null) {
                removeAllSubTypes = removeThisSubType;
            } else {
                removeAllSubTypes = Expression
                    .AndAlso(removeAllSubTypes, removeThisSubType);
            }
        }
        // Convert to a lambda (actually pass the parameter in)
        var removeAllSubTypesLambda = Expression
             .Lambda(removeAllSubTypes, parameter);
        // Filter the query
        return query
            .OfType<ReturnType>()
            .Where(removeAllSubTypesLambda as Expression<Func<ReturnType, bool>>);
    }
