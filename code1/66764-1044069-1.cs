    public abstract class CollectionBase<T> : IList<T>
    {
       ...
       public Type ElementType
       {
          get
          {
             return typeof(T);
          }
       }
    }
