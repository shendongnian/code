    foreach (Type itf in list.GetType().GetInterfaces())
    {
      if (itf.IsGenericType && itf.GetGenericTypeDefinition == typeof(IList<>))  // note generic type definition syntax
      {
        listItemType = itf.GetGenericArguments()[0];
      }
    }
