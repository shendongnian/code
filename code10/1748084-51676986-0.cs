    public static Expression<Func<TEntity, int>> GetOrderByArrayPriorityExpression<TEntity, TValue>(this Expression<Func<TEntity, TValue>> selectorExpression, TValue[] orderedValues)
    {       
        var body = orderedValues.Select((value, index) => new {
            //Note: Build the expressions using the same parameter to avoid having to use Expression Visitor
            //x => x.Property == {value}
            Condition = Expression.Equal(selectorExpression.Body, Expression.Constant(value, typeof(TValue))),
            Priority = Expression.Constant(index)
        }).Aggregate((Expression)Expression.Constant(int.MaxValue), (accumulated, nextPriorityExpression) =>
            //This generates the conditions (in reverse which is also fine)
            // x =>
            // x.Property == {GlobalOwnerGuid} ? 3 : 
            // x.Property == {ClientOwnerGuid} ? 2 :
            // x.Property == {CompanyOwnerGuid} ? 1 :
            // x.Property == {DivisionOwnerGuid} ? 0 : Int.MaxValue
            Expression.Condition(nextPriorityExpression.Condition, nextPriorityExpression.Priority, accumulated)
        );
            
        // reuse to original parameter to avoid using an expression visitor
        return (Expression<Func<TEntity, int>>)Expression.Lambda(body, selectorExpression.Parameters);
    }
