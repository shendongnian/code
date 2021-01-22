    public class MyList<T>:List<T>
    {
      public new MyList<T> Add(T item)
      {
         (this as ICollection<T>).Add(item);
         return this;
      }
    }
