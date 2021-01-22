    var bytes = new List<byte>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    	
    var result = bytes
    		 .Select( (b,i) => bytes.Skip(i*4).Take(4) )
    		 .Select( c => c.Count() >0 && c.Count() < 4
                            ? c.Concat( Enumerable.Repeat((byte)0, 4-c.Count() ) ) 
                            : c );
