    List<string> Permute( string s )
    {
      List<string> listPermutations = new List<string>();
    
      char[] array = s.ToLower().ToCharArray();
      listPermutations.Add( s.ToLower() );
    
      for( int i = 0; i < array.Length; i++ )
      {
        for( int j = i; j < array.Length; j++ )
        {
          array[j] = char.ToUpper( array[j] );
          listPermutations.Add( new string( array ) );
          array[j] = char.ToLower( array[j] );
        }
        array[i] = char.ToUpper( array[i] );
      }
      
      return listPermutations;
    }
