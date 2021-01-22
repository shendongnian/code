static Dictionary<Type, Delegate> table = 
	new Dictionary<Type, Delegate>{
		{ typeof(int), (Func<string,int>)Int32.Parse },
		{ typeof(double), (Func<string,double>)Double.Parse },
		// ... as many as you want
	};
static T Parse<T>(string str)
{
	if (!table.TryGet(typeof(T), out Delegate func))
		throw new ArgumentException();
	var typedFunc = (Func<string, T>)func;
	return typedFunc(str);
}
When in trouble with types, try delegates and dicts!
