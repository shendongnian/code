    if (myObject is IEnumerable)
    {
       List<object> list = new List<object>();
       var enumerator = ((IEnumerable) myObject).GetEnumerator();
       while (enumerator.MoveNext())
       {
          list.Add(enumerator.Current);
       }
    }
