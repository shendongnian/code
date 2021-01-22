    //counting backwards is easier when you are doing removals from a list
    for( int i = lst.Count -1; i>= 0; i--)
    {
        if(condition1 || condition2)
        { lst.RemoveAt(i); }
    }
