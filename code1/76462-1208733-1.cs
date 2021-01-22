    Func<int,int> badRec = null;
    badRec = x => ( x <= 1 ) ? 1 : x * badRec( x - 1 );
    
    Func<int,int> badRecCopy = badRec;
    	
    badRec = x => x + 1;
    	
    Console.WriteLine( badRec(4) );
    Console.WriteLine( badRecCopy(5) );
    // Output
    // 5
    // 25
