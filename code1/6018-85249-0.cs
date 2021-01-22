    public class MyList<T>
    {
      private List<T> _list;
    ...
    public T GetValue(int index)
    {
      return _list[index];
    }
