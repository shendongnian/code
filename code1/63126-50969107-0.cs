    /// <summary>An array indexed by an Enum</summary>
    /// <typeparam name="T">Type stored in array</typeparam>
    /// <typeparam name="U">Indexer Enum type</typeparam>
    public class ArrayByEnum<T,U> : IEnumerable where U : Enum // requires C# 7.3 or later
    {
      private readonly T[] _array;
      public ArrayByEnum()
      {
        U max = Enum.GetValues(typeof(U)).Cast<U>().Max();
        _array = new T[Convert.ToInt32(max) + 1];
      }
      public T this[U key]
      {
        get { return _array[Convert.ToInt32(key)]; }
        set { _array[Convert.ToInt32(key)] = value; }
      }
      public IEnumerator GetEnumerator()
      {
        return _array.GetEnumerator();
      }
    }
