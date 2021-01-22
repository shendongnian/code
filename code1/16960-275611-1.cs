            public static string Capitalize( this string word )
    		{
    			// the aggregate at the end is necessary because IEnumberable<char>.ToString doesn't do 
    			// what I want, it returns something like System.Linq.Enumerable+d__4d`1[System.Char]
    			return word[0].ToString( ).ToUpper( ) + word.Skip( 1 ).Aggregate( "", ( s, c ) => s + c );
    		}
