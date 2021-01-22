    public Func<T, TResult> Memoize<T, TResult>(Func<T, TResult> func)
    {
        Dictionary<T, TResult> _resultsCache = new Dictionary<T, TResult>();
    	return (arg) =>
    	{
    	    TResult result;
    	    if (!_resultsCache.TryGetValue(arg, out result))
    		{
    			result = func(arg);
    			_resultsCache.Add(arg, result);
    		}
    		return result;
    	};
    }
    ...
    Func<int, int> factorial = null; // Just so we can refer to it
    factorial = x => x <= 1 ? 1 : x * factorial(x-1);
    var factorialMemoized = Memoize(factorial);
    var res = Enumerable.Range(1, 10).Select(x => factorialMemoized(x));
    foreach (var outt in res)
        Console.WriteLine(outt.ToString());
