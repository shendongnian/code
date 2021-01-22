public class BaseCollection&lt;T&gt;
{
  // void return - doesn't seem to care about notifying the 
  // client where the item was added; it has an IndexOf method 
  // the caller can use if wants that information
  public virtual void Add(T item)
  {
    // adds the item somewhere, doesn't say where
  }
  public int IndexOf(T item)
  {
     // tells where the item is
  }
}
public class List&lt;T&gt; : BaseCollection&lt;T&gt;
{
  // here we have an Int32 return because our List is friendly 
  // and will tell the caller where the item was added
  new public virtual int Add(T item) // &lt;-- clearly not an override
  {
     base.Add(item);
     return base.IndexOf(item);
  }
}
