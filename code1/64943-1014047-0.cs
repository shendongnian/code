    public abstract class ABCBase<T>
    {
       protected IList<T> m_List = new List<T>();
       // methods that manage the collection
       // I chose to make the virtual so that derived 
       // classes could alter then behavior - may not be needed
       public virtual void Add( T item )    { ... }
       public virtual void Remove( T item ) { ... }
       public virtual int  Find( T item )   { ... } 
    }
    
    public class A : ABCBase<X> { ... }
    
    public class B : ABCBase<Y> { ... }
    
    public class C : ABCBase<Z> { ... }
