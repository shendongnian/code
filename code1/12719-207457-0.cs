    for( int idx = 0; idx < list.Count ; idx++ )
    {
        if( list[idx].Rating < 1000 )
        {
            list.RemoveAt(idx); // whoops!
        }
    }
