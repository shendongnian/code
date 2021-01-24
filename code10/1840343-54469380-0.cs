    List<bool> list = new List<bool>();
    foreach (var i in list.GetType().GetInterfaces())
    {
      if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>))
      { }
    }
