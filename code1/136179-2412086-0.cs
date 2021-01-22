    // modify this as appropriate to divide your original input string...
    public IEnumerable<string> Divide( string s )
    { 
        for( int i = 0; i < s.Length; i += 2 )
            yield return s.Substring( i, 2 );
    }
    public IEnumerable<bool> AsBoolArray( byte b )
    {
        var i = 4; // assume we only want 4-bits
        while( i-- > 0 )
        {
            yield return (b & 0x01) != 0;
            b >>= 1;
        }
    }
    // define your own mapping table...
    var mappingTable = 
      new Dictionary<string,int>() { {"cn", 1}, {"pl",23}, {"vf",3}, {"vv",0} /*...*/ };
    var originalString = "cncnvfvvplvvplpl";
    // encode the data by mapping each string to the dictionary...
    var encodedData = DivideString( originalString ).Select( s => mappingTable[s] );
    // then convert into a bitVector based on the boolean representation of each value...
    // The AsBoolArray() method return the 4-bit encoded bool[] for each value
    var packedBitVector = 
      new BitArray( encodedData.Select( x => AsBoolArray(x) ).ToArray() );
    // you can use BitArray.CopyTo() to get the representation out as a packed int[]
