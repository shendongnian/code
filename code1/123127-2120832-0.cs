    public static MyMethod<T>()
    {
      if(typeof(T) == typeof(Int32))
      {
        return 0;
      }
      else
      {
       return default(T); // or null
      }
    }
