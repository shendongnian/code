    public static bool IsNumericType(this object o)
    {   
      var t = Type.GetTypeCode(o.GetType());
      return (int)t >= 5 && (int)t <= 15;
    }
