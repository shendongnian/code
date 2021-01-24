    Expression<Func<IConfigurationValue, int>> GetOrderByExpression(
        Guid[] ownerKeyByPriority) {
    
        // x =>
        var parameter = Expression.Parameter(typeof(IConfigurationValue));
        var body = ownerKeyByPriority.Select((ownerKey, index) => new {
            // Hack: Build the expressions using the same parameter
            // to avoid having to use Expression Visitor
            Test = this.GetCondition(parameter, ownerKey),
            Priority = Expression.Constant(index)
        }).Aggregate((Expression)Expression.Constant(int.MaxValue), (accumulated, nextPriorityExpression) =>
            Expression.Condition(nextPriorityExpression.Test, nextPriorityExpression.Priority, accumulated)
        );
        
        return (Expression<Func<IConfigurationValue, int>>)Expression.Lambda(body, parameter);
    }
