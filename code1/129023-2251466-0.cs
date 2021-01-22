    public class MyList<T> : List<T>
    {
      public MyList(List<T> list)
      {
        AddRange(list);
      }
    }
