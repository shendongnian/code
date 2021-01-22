<PRE>
      static void Main( string[] args )
      {
         string[] paths = new string[] { "S:\\hello\\Hi", "S:\\hello2\\Hi\\helloAgain" };
         foreach( string aPath in paths )
         {
            string normalizedPath = NormalizePath( aPath );
            Console.WriteLine( "Previous: '{0}', Normalized: '{1}'", aPath, normalizedPath );
         }
         Console.Write( "\n\n\nPress any key..." );
         Console.Read();
      }
      public static string NormalizePath( string path )
      {
         StringBuilder sb = new StringBuilder( path );
         string[] paths = path.Split('\\');
         foreach( string folderName in paths )
         {
            string normalizedFolderName = ToProperCase( folderName );
            sb.Replace( folderName, normalizedFolderName );
         }
         return sb.ToString();
      }
      /// <summary>
      /// Converts a string to first character upper and rest lower (Camel Case).
      /// </summary>
      /// <param name="stringValue"></param>
      /// <returns></returns>
      public static string ToProperCase( string stringValue )
      {
         if( string.IsNullOrEmpty( stringValue ) )
            return stringValue;
         return CultureInfo.CurrentCulture.TextInfo.ToTitleCase( stringValue.ToLower() );
      }
</PRE>
