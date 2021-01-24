	public static void Evaluate<TObj,TProp>(
        this TObj obj, 
        Expression<Func<TObj, TProp>> expr)
    {
		var prop = (expr.Body as MemberExpression)?.Member as PropertyInfo;
		var val = prop?.GetValue(obj);
		if (val != null) {
            //Do something
        }
    }
