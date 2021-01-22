    public static T To<T>(this IConvertible obj)
    {
      return (T)Convert.ChangeType(obj, typeof(T));
    }
    public static T ToOrDefault<T>
                 (this IConvertible obj)
    {
        try
        {
            return To<T>(obj);
        }
        catch
        {
            return default(T);
        }
    }
    public static bool ToOrDefault<T>
                        (this IConvertible obj,
                         out T newObj)
    {
        try
        {
            newObj = To<T>(obj); 
            return true;
        }
        catch
        {
            newObj = default(T); 
            return false;
        }
    }
    public static T ToOrOther<T>
                           (this IConvertible obj,
                           T other)
    {
      try
      {
          return To<T>obj);
      }
      catch
      {
          return other;
      }
    }
    public static bool ToOrOther<T>
                             (this IConvertible obj,
                             out T newObj,
                             T other)
    {
        try
        {
            newObj = To<T>(obj);
            return true;
        }
        catch
        {
            newObj = other;
            return false;
        }
    }
    public static T ToOrNull<T>
                          (this IConvertible obj)
                          where T : class
    {
        try
        {
            return To<T>(obj);
        }
        catch
        {
            return null;
        }
    }
    public static bool ToOrNull<T>
                      (this IConvertible obj,
                      out T newObj)
                      where T : class
    {
        try
        {
            newObj = To<T>(obj);
            return true;
        }
        catch
        {
            newObj = null;
            return false;
        }
    }
