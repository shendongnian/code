    class List<A>
    {
    }
    
    class Nil<A> : List<A>
    {
    	public Nil() {}
    }
    
    class Cons<A> : List<A>
    {
    	public A Head;
    	public List<A> Tail;
    
    	public Cons(A head, List<A> tail)
    	{
    		this.Head = head;
    		this.Tail = tail;
    	}
    }
