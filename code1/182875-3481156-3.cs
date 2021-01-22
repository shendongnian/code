    public Tuple<string,bool> SearchDictionary( string searchKey )
    {
        string value;
        bool wasFound = someDictionary.TryGetValue( searchKey, out value );
        return new Tuple<string,bool( value, wasFound );
    }
    // since <null> is a legal value to store in the dictionary, we cannot
    // use it to distinguish between 'value not found' and 'value is null'.
    // the Tuple<string,bool>, however, does allow us to do so...
    var result = SearchDictionary( "somekey" );
    if( result.Item2 )
    {
        Console.WriteLine( result.Item1 );
    }
