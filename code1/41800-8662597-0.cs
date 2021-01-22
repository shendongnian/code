    //Person has private ctor
    var person = Factory<Person>.Create(p => p.Name = "Daniel");
    public static class Factory<T> where T : class 
    {
    	private static readonly Func<T> FactoryFn;
    
    	static Factory()
    	{
    		//FactoryFn = CreateUsingActivator();
    
    		FactoryFn = CreateUsingLambdas();
    	}
    
    	private static Func<T> CreateUsingActivator()
    	{
    		var type = typeof(T);
    
    		Func<T> f = () => Activator.CreateInstance(type, true) as T;
    
    		return f;
    	}
    
    	private static Func<T> CreateUsingLambdas()
    	{
    		var type = typeof(T);
    
    		var ctor = type.GetConstructor(
    			BindingFlags.Instance | BindingFlags.CreateInstance |
    			BindingFlags.NonPublic,
    			null, new Type[] { }, null);
    
    		var ctorExpression = Expression.New(ctor);
    		return Expression.Lambda<Func<T>>(ctorExpression).Compile();
    	}
    
    	public static T Create(Action<T> init)
    	{
    		var instance = FactoryFn();
    
    		init(instance);
    
    		return instance;
    	}
    }
