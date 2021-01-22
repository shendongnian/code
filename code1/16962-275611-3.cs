            public static string Capitalize( this string word )
    		{
    			// The aggregate is because IEnumerable<char>.ToString doesn't return the characters as a string, it returns the type's name as a string.
    			return word[0].ToString( ).ToUpper( ) + word.Skip( 1 ).Aggregate( "", ( s, c ) => s + c );
    		}
