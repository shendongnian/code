    IEnumerable<T> MergeOrderedLists<T, TOrder>( IEnumerable<IEnumerable<T>> orderedlists, Func<T, TOrder> orderBy )
    {
    	var enumerators = orderedlists.Select( enumerable => enumerable.GetEnumerator() ).ToList();
    	foreach( var enumerator in enumerators )
    	{
    		enumerator.MoveNext();
    	}
    
    	while( enumerators.Count != 0 )
    	{
    		var enumerator = enumerators.OrderBy( e => orderBy( e.Current ) ).First();
    		yield return enumerator.Current;
    		if( !enumerator.MoveNext() )
    		{
    			enumerators.Remove( enumerator );
    		}
    	}
    }
