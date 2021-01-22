    IEnumerator enumerator = myEnumerable.GetEnumerator();
    string myDelimitedString;
    while( true )
    {
        try{ myDelimitedString = (string)enumerator.Current; }
        catch{ break; }
        if( enumerator.MoveNext() )
            myDelimitedString += DELIMITER;
        else
            break;
    }
