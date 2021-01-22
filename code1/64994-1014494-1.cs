    var iterator = _InternalCollection.GetEnumerator();
    int i = _InternalCollection.Count;
    while( iterator.MoveNext() && i-- > 10 )
    {
      ;  // skip first N-10 items...
    }
    while( iterator.MoveNext() )
    {
      newStack.Push( iterator.Current );
    }
    newStack.Reverse(); 
    _InternalCollection = newStack;
