    var myDictionary = new Dictionary<int, List<string>>();
    // .....
    List<string> myList;
    myDictionary.TryGetValue( id, out myList );
    if ( null == myList ) {
        myList = new List<string>();
        myDictionary[id] = myList;
    }
    myList.Add( "hello world" );
