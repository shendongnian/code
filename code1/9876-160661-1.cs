    Func<int, bool>[] criteria = new Func<int, bool>[3]; 
    criteria[0] = i => i % 2 == 0; 
    criteria[1] = i => i % 3 == 0; 
    criteria[2] = i => i % 5 == 0;
    Expression<Func<int, bool>>[] results = new Expression<Func<int, bool>>[criteria.Length];
    for (int i = 0; i < criteria.Length; i++)
    {
        results[i] = f => true; 
        for (int j = 0; j <= i; j++)
        {
            int ii = i;
            int jj = j;
            Expression<Func<int, bool>> expr = b => criteria[jj](b); 
            var invokedExpr = Expression.Invoke(expr, results[ii].Parameters.Cast<Expression>()); 
            results[ii] = Expression.Lambda<Func<int, bool>>(Expression.And(results[ii].Body, invokedExpr), results[ii].Parameters);
        }
    } 
    var predicates = results.Select(e => e.Compile()).ToArray(); 
