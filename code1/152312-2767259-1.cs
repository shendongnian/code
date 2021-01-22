    IEnumerable<T> MergeOrderedLists<T, TOrder>( IEnumerable<IEnumerable<T>> orderedlists, Func<T, TOrder> orderBy )
    {
        // Get an enumerator for each list
    	var enumerators = orderedlists.Select( enumerable => enumerable.GetEnumerator() ).ToList();
        // Point each enumerator onto the first element
    	foreach( var enumerator in enumerators )
    	{
        	// Missing: assert true as the return value
    		enumerator.MoveNext();
    	}
    
    	// Loop as long as we have at least one enumerator
    	// (enumerators that passed their list will be removed)
    	while( enumerators.Count != 0 )
    	{
    		// Get the enumerator that points to the first ordered element
    		var enumerator = enumerators.OrderBy( e => orderBy( e.Current ) ).First();
    		// Return this enumerators current value
    		yield return enumerator.Current;
    		// And move to the next element
    		if( !enumerator.MoveNext() )
    		{
    			// No next value? This enumerator passed the whole list -> remove it
    			enumerators.Remove( enumerator );
    		}
    	}
    }
