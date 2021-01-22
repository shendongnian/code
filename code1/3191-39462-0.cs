    IEnumerable<object> FilteredList()
    {
        foreach( object item in FullList )
        {
            if( IsItemInPartialList( item )
                yield return item;
        }
    }
