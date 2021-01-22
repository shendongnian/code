    public class ListManager<T>
    {
       private IList<T> m_List = new List<T>();
    
       public void Add( T item )    { ... }
       public void Remove( T item ) { ... }
       public int  Find( T item )   { ... }
    }
    public class A
    {
       public ListManager<X> ListOfX { get; protected set; }
    
       public A() { ListOfX = new ListManager<X>(); }
    }
    
    public class B
    {
       public ListManager<Y> ListOfX { get; protected set; }
    
       public B() { ListOfY = new ListManager<Y>(); }
    }
    
    public class C
    {
       public ListManager<Z> ListOfX { get; protected set; }
    
       public C() { ListOfX = new ListManager<Z>(); }
    }
