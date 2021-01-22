            IQueryable query = entities.People;
            Type[] exprArgTypes = { query.ElementType };
            string propToWhere = "FirstName";            
            ParameterExpression p = Expression.Parameter(typeof(People), "p");
            MemberExpression member = Expression.PropertyOrField(p, propToWhere);
            LambdaExpression lambda = Expression.Lambda<Func<People, bool>>(Expression.Equal(member, Expression.Constant("Scott")), p);                            
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable), "Where", exprArgTypes, query.Expression, lambda);
            IQueryable q = query.Provider.CreateQuery(methodCall);
