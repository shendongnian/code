    var firstEnum = aIEnumerable.GetEnumerator();
    var secondEnum = bIEnumerable.GetEnumerator();
        
    // Using non-shortcircuit operators, so both will run.
    while (firstEnum.MoveNext() & secondEnum.MoveNext())
    {
          // Do whatever.
    }
    
    if (firstEnum.MoveNext() | secondEnum.MoveNext())
    {
         Throw new Exception("One Enum is bigger");
    }
    // IEnumerator does not have a Dispose method, but IEnumerator<T> has.
    if (firstEnum is IDisposable) { firstEnum.Dispose(); }
    if (secondEnum is IDisposable) { secondEnum.Dispose(); }
