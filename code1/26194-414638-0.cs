    public class LinkedListWithInit<T> : LinkedList<T>
    {
    	public void Add( T item )
    	{
    	    ((ICollection<T>)this).Add(item);
    	}
    }
    LinkedList<int> list = new LinkedListWithInit<int> { 1, 2, 3, 4, 5 };
