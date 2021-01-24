    Func<Command, Task<object>> MakeFunc(MethodInfo handler)
    {
    	var c = Expression.Parameter(typeof(Command), "c");
    	var task = Expression.Call(Expression.Constant(this), handler, c);
    	if (task.Type != typeof(Task<object>))
    		task = Expression.Call(GetType(), "Convert", new[] { task.Type.GetGenericArguments().Single() }, task);
    	var expr = Expression.Lambda<Func<Command, Task<object>>>(task, c);
    	return expr.Compile();
    }
