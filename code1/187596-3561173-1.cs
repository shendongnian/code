    public static IEnumerable<string> AllCodes()
    {
      char[] characters = {a, b, c... z}; 
      IEnumerable<char[]> codeSets = new[] { characters, characters, characters };
      foreach( var codeValues in codeSets.CartesianProduct() )
      {
        yield return 
           string.Format( "{0}{1}{2}", codeValues[0], codeValues[1], codeValues[2]);
      }
    }
