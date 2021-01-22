    using System.Collections;
    
    public abstract class BaseParent { }
    
    public abstract class ChildCollectionItem<T>
      where T : BaseParent
    {
      public T parent;
    
      public ChildCollection<T> owningCollection;
    }
    
    public abstract class ChildCollection<T> : CollectionBase
      where T : BaseParent
    {
    }
    
    public abstract class ChildCollection<T, U> : ChildCollection<T>
      where T : BaseParent
      where U : ChildCollectionItem<T>
    {
      public T parent;
    
      public int Add(U item)
      {
        int indexAdded = this.List.Add(item);
        item.owningCollection = this;
        return indexAdded;
      }
    }
