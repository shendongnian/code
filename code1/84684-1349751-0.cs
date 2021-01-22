    public class MyList<T>:List<T>
    {
      public MyList<T> Add(T item)
      {
         (this as ICollection<T>).Add(item);
         return this;
      }
    }
