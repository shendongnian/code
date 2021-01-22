    ParameterExpression valueBag = Expression.Parameter(typeof(Dictionary<string, object>), "valueBag");
    ParameterExpression key = Expression.Parameter(typeof(string), "key");
    ParameterExpression result = Expression.Parameter(typeof(object), "result");
    BlockExpression block = Expression.Block(
      new[] { result },               //make the result a variable in scope for the block           
      Expression.Assign(result, Expression.Property(valueBag, "Item", key)),
      result                          //last value Expression becomes the return of the block 
    );
