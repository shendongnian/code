    void Main()
    {
    	IObservable<bool> obsBool = null;
    	IObservable<int?> obsInt = null;
    	Action<bool, int?> doSomething = null;
    
    	obsBool
    		.CombineLatest(obsInt)
    		.Subscribe(t => doSomething(t.Item1, t.Item2));
    }
    
    public static class X
    {
    	public static IObservable<(T1, T2)> CombineLatest<T1, T2>(this IObservable<T1> o1, IObservable<T2> o2)
    	{
    		return o1.CombineLatest(o2, (t1, t2) => (t1, t2));
    	}
    }
