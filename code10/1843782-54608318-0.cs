      var originalText = "oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:oifwoeifjw fe fewfwewefjio wef:";
    
      Console.WriteLine( originalText );
      var part = string.Empty;
    
      Console.WriteLine( part );
      var index = 0; //--> define this outside the loop, so you can use it to pick up any remainder
      var width = 30;  //--> ...or whatever width you need
    
      for ( index = 0; index < ( originalText.Length - width ); index += width )
      {
        part = originalText.Substring( index, width );
        //--> do something useful with s
        Console.WriteLine( part );
      }
    
      //--> deal with the remainder, if any...
      if ( index < originalText.Length )
      {
        //--> the last piece...
        part = originalText.Substring( index, originalText.Length - index );
        Console.WriteLine( part );
      }
