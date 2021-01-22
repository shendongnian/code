    public static void Dynamight<T>(this T target, Action<dynamic> action)
    {
      dynamic d = target;
      try
      {
        action(d);
      }
      catch (RuntimeBinderException)
      {
        //That was that, didn't work out
      }
    }
