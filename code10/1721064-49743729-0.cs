    public class ParentClass<T>{
      protected T item;
      public T ItemValue
      {
        set
        {
            item = value;
        }
        get
        {
            return item;
        }
      }
    }
    public class ChildClass:ParentClass<Child>
    {
        // No need to create a new definition of item
    }
