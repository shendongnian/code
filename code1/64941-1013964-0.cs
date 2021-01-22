    interface ILetter<T>
    {
    	IList<T> OtherObjects { get; }
    }
    class A : ILetter<Class_X> 
    {
    	public IList<Class_X> OtherObjects
    	{
    		get { /* ... */ }
    	}
    }
    class B : ILetter<Class_Y> 
    {
    	public IList<Class_X> OtherObjects
    	{
    		get { /* ... */ }
    	}
    }
    
    // etc...
