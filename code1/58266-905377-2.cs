    public static List<string> Permute( string s )
    {
      List<string> listPermutations = new List<string>();
    	
      char[] array = s.ToLower().ToCharArray();
      int iterations = (1 << array.Length) - 1;
    	
      for( int i = 0; i <= iterations; i++ )
      {
        for( int j = 0; j < array.Length; j++ )
        array[j] = (i & (1<<j)) != 0 
                      ? char.ToUpper( array[j] ) 
                      : char.ToLower( array[j] );
        listPermutations.Add( new string( array ) );
      }
      return listPermutations;
    }
