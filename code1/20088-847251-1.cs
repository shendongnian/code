    private static string MakeValidFileName( string name )
    {
       string invalidChars = Regex.Escape( new string( Path.GetInvalidFileNameChars() ) );
       string invalidReStr = string.Format( @"[{0}]+", invalidChars );
       return Regex.Replace( name, invalidReStr, "_" );
    }
