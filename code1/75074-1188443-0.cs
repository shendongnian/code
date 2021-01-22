    public class Collection<T>
    {
        ...
    }
    public static class CollectionExtentions
    {
    	public static bool Equals<T,U>(
                this Collection<T> first, 
                Collection<T> other, 
                EqualityComparer<U> eq) where T : U
    	{
                ... // legal to use eq here on the T values with collections
    	}
    }
