    public static Expression<Func<Package,bool>> IsShippedOrInProgress() {
    
    	// Compose the expression tree that represents the parameter to the predicate.  
    	ParameterExpression p = Expression.Parameter(typeof(Package), "p");  
    	
    	// Compose left side of the expression i.e `p.StatusId`
    	Expression left = Expression.Call(p, typeof(Package).GetProperty("StatusId"));  
    	
    	// Compose right side of the expression i.e `(int)PackageStatus.InProgress` etc.
    	Expression exprInProgress = Expression.Constant((int)PackageStatus.InProgress);  
        Expression exprDelivered = Expression.Constant((int)PackageStatus.Delivered);  
    	Expression exprShipped = Expression.Constant((int)PackageStatus.Shipped);  
    	Expression exprWaiting = Expression.Constant((int)PackageStatus.Waiting);  
    	
    	// Compose left equals right side
    	Expression e1 = Expression.Equal(left, exprInProgress);  
    	Expression e2 = Expression.Equal(left, exprDelivered);  
    	Expression e3 = Expression.Equal(left, exprShipped);  
    	Expression e4 = Expression.Equal(left, exprWaiting);  
    	
    	//Compose `p.StatusId == (int)PackageStatus.InProgress ||
        //       p.StatusId == (int)PackageStatus.Delivered ||
        //       p.StatusId == (int)PackageStatus.Shipped ||
        //       p.StatusId == (int)PackageStatus.Waiting`
    	Expression orConditions = Expressions.OrElse(Expression.OrElse(Expression.OrElse(e1,e2),e3),e4);
    	
    	//Compose `p => 
        //        p.StatusId == (int)PackageStatus.InProgress ||
        //        p.StatusId == (int)PackageStatus.Delivered ||
        //        p.StatusId == (int)PackageStatus.Shipped ||
        //        p.StatusId == (int)PackageStatus.Waiting`
        return Expression.Lambda<Func<Package, bool>>(orConditions, new ParameterExpression[] { p })); 
    
    }
