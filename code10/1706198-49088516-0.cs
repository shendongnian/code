    public abstract class ParentClass
    {
    	public T ParentMethod<T>() where T:ParentClass
    	{
    		return (T)this; 
        }
    }
