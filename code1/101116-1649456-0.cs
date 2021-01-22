    public static string GetName<T>(Func<T> expr)
    {
      var il = expr.Method.GetMethodBody().GetILAsByteArray();
      return expr.Target.GetType().Module.ResolveField(BitConverter.ToInt32(il, 2)).Name; 
    }
