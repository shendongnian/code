    public static T MyMethod<T>()
    {
      if(typeof(T) == typeof(Int32))
      {
        return (T)(object)0;
      }
      else
      {
       return default(T); // or null
      }
    }
