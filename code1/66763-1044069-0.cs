    public abstract class CollectionBase<T> : IList<T>
    {
       ...
       public Type ElementType
       {
          return typeof(T);
       }
    }
