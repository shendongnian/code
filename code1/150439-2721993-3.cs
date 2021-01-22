    var firstEnum = aIEnumerable.GetEnumerator();
    var secondEnum = bIEnumerable.GetEnumerator();
    
    var firstEnumMoreItems = firstEnum.MoveNext();
    var secondEnumMoreItems = secondEnum.MoveNext();    
    
    while (firstEnumMoreItems && secondEnumMoreItems)
    {
          // Do whatever.  
          firstEnumMoreItems = firstEnum.MoveNext();
          secondEnumMoreItems = secondEnum.MoveNext();   
    }
    
    if (firstEnumMoreItems || secondEnumMoreItems)
    {
         Throw new Exception("One Enum is bigger");
    }
    // IEnumerator does not have a Dispose method, but IEnumerator<T> has.
    if (firstEnum is IDisposable) { firstEnum.Dispose(); }
    if (secondEnum is IDisposable) { secondEnum.Dispose(); }
