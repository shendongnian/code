    public static int[] ToUtf32CodePoints( this string s )
    {
      if ( s == null ) throw new NullReferenceException();
      
      byte[] octets = Encoding.UTF32.GetBytes( s ) ;
      List<int> codePoints = new List<int>( octets.Length/sizeof(int) );
      
      for ( int i = 0 ; i < octets.Length ; i+=4 )
      {
        int codePoint = BitConverter.ToInt32(octets,i);
        codePoints.Add(codePoint);
      }
      
      return codePoints.ToArray();
    }
