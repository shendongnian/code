    public class SuperLazy<T> : Lazy<T>
        where T : new()
    {
    	public SuperLazy()
    		 : base(() => new T())
    	{
    	}
    }
