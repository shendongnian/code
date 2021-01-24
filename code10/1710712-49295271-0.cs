    var obj = Expression.Variable(newObj.Type, "obj");
    var expressions = new List<Expression>();
    expressions.Add(Expression.Assign(obj, newObj));
    expressions.AddRange(memberBindings.Select(b => Expression.Assign(
    	Expression.MakeMemberAccess(obj, b.Member), b.Expression)));
    expressions.Add(obj);
    var variables = new Expression[] { obj };
    var result = Expression.Block(variables, expressions);
