    ICollection<T> selected = new Collection<T>();
    var indexesIndex = 0;
    var collectionIndex = 0;
    foreach( var item in collection )
    {
    	if( indexes[indexesIndex] != collectionIndex++ )
    	{
    		continue;
    	}
    	selected.Add( item );
    	if( ++indexesIndex == indexes.Count )
    	{
    		break;
    	}
    }
