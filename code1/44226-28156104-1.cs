    public static IEnumerable<int> Utf32CodePoints( this IEnumerable<char> s )
    {
      bool      useBigEndian = !BitConverter.IsLittleEndian;
      Encoding  utf32        = new UTF32Encoding( useBigEndian , false , true ) ;
      byte[]    octets       = utf32.GetBytes( s ) ;
      for ( int i = 0 ; i < octets.Length ; i+=4 )
      {
        int codePoint = BitConverter.ToInt32(octets,i);
        yield return codePoint;
      }
      
    }
