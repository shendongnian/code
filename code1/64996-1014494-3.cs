    var iterator = _InternalCollection.GetEnumerator();
    int i = 9;
    while( iterator.MoveNext() && i-- >= 0 )
    {
       newStack.Push( iterator.Current );
    }
    _InternalCollection = newStack;
