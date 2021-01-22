    System.Globalization.NumberFormatInfo nf
      = new System.Globalization.NumberFormatInfo ( )
    {
      NumberGroupSeparator = "."
    };
    float f = float.Parse ( "5.34534", nf );
