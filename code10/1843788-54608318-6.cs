      var originalText = "Now is the time; yada yada; thing and the thing! Now is the time; yada yada; thing and the thing! Now is the time; yada yada; thing and the thing! Now is the time; yada yada; thing and the thing! Now is the time; yada yada; thing and the thing! Now is the time; yada yada; thing and the thing! Now is the time; yada yada; thing and the thing! ";
    
      txtBoxContent.Clear();
      var part = string.Empty;
    
      var index = 0; //--> define this outside the loop, so you can use it to pick up any remainder
      var width = 30;  //--> ...or whatever width you need
    
      for ( index = 0; index < ( originalText.Length - width ); index += width )
      {
        part = originalText.Substring( index, width );
        //--> do something useful with the fixed-length part...
        txtBoxContent.Append( part + Environment.NewLine );
      }
    
      //--> deal with the remainder, if any...
      if ( index < originalText.Length )
      {
        //--> the last piece...it will be less than width wide...
        part = originalText.Substring( index, originalText.Length - index );
        txtBoxContent.Append( part );
      }
