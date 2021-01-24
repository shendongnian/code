    var zero = Expression.Constant(0);
    var one = Expression.Constant(1);
    matchCountReplacement = !ExpressionMatchList.Any() ? zero : ExpressionMatchList
    	.Select(e => Expression.Condition(
    		e.Body.ReplaceParameter(e.Parameters[0], selectorParameter),
    		one, zero))
    	.Aggregate<Expression>(Expression.Add);
    selectorBody = selectorBody.ReplaceParameter(matchCountParameter, matchCountReplacement);
