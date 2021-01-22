    public static T MyMethod<T>()
    {
      if(typeof(T) == typeof(Int32))
      {
        return 0;
      }
      else
      {
        return "nothing";
      }
    }
