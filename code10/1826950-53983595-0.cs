    using DynamicLinq = System.Linq.Dynamic;
    using LinqExpression = System.Linq.Expressions;
    public static IQueryable JoinQuery(this IQueryable outer, IEnumerable innerEntities, string firstEntityPropName, 
    	Type typeSecondEntity, Type typeResultEntity, params object[] values)
    {
    	if (innerEntities == null) throw new ArgumentNullException(nameof(innerEntities));
    	if (firstEntityPropName == null) throw new ArgumentNullException(nameof(firstEntityPropName));
    	if (typeSecondEntity == null) throw new ArgumentNullException(nameof(typeSecondEntity));
    	if (typeResultEntity == null) throw new ArgumentNullException(nameof(typeResultEntity));
    
    	LambdaExpression outerSelectorLambda = DynamicLinq.DynamicExpression.ParseLambda(outer.ElementType, null, firstEntityPropName, values);
       
    	ParameterExpression expnInput = Expression.Parameter(typeSecondEntity, "inner");
    
    	ParameterExpression[] parameters = new ParameterExpression[] {
    	Expression.Parameter(outer.ElementType, "outer"), Expression.Parameter(innerEntities.AsQueryable().ElementType, "inner")
    	};
    
    	LambdaExpression selectorSecondEntity = DynamicLinq.DynamicExpression.ParseLambda(new ParameterExpression[] { expnInput }, typeSecondEntity, "inner");
    	LambdaExpression selectorResult = DynamicLinq.DynamicExpression.ParseLambda(parameters, typeResultEntity, "outer");
    
    	return outer.Provider.CreateQuery(
    	   Expression.Call(
    		   typeof(Queryable), "Join",
    		   new Type[] { outer.ElementType, innerEntities.AsQueryable().ElementType, outerSelectorLambda.Body.Type, selectorResult.Body.Type },
    		   outer.Expression, innerEntities.AsQueryable().Expression, Expression.Quote(outerSelectorLambda), Expression.Quote(selectorSecondEntity),
    		  Expression.Quote(selectorResult)));
    }
