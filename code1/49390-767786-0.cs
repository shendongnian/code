    public void ContainTheDanger<T>(Expression<Func<T>> dangerousCall)
    {
    	try
    	{
    		var expr = dangerousCall.Compile();
    		expr.Invoke();
    	}
    	catch (Exception e)
    	{
    		Expression<Func<T>> DangerousExpression = dangerousCall;
    		var nameOfDanger = ((MethodCallExpression)dangerousCall.Body).Method.Name;
    		throw new DangerContainer("Danger manifested while " + nameOfDanger, e);
    	}
    }
    
    public void SomewhereElse()
    {
    	var thing = new Thing();
    	ContainTheDanger(() => thing.CrossTheStreams());
    }
