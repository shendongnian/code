    public class MyFactory<T> : IMyFactory<T> where T :BaseType, new()
    {
        public readonly Type typeToInstantiate;
	
    	public MyFactory()
	    {
	        typeToInstantiate = typeof(T);
    	}
	
	    public T Resolve()
    	{
	        return new T();
    	}
    }
