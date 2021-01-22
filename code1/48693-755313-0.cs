    if (t.IsGenericType) {
      if (typeof(List<>) == t.GetGenericTypeDefinition()) {
        Type lt = t.GetGenericArguments()[0];
        List<lt> x = (List<lt>)o;
        stringifyList(x);
      }
    }
