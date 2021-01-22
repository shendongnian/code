    public class Owned<T> : IDisposable
    {
       private readonly Container container;
       private readonly T value;
       public Owned(Container container, T value)
       {
          this.container = container;
          this.value = value;
       }
    
       public T Value { get { return value; } }
    
       public void Dispose()
       {
          this.container.ReleaseOwned(this);
       }
    
    }
