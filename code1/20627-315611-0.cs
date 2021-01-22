      public static Bitmap GetBitmap( string filename )
      {
         Bitmap retBitmap = null;
         string path = String.Concat( BitmapDir, filename );
         if ( File.Exists( path ) )
         {
            try
            {
               retBitmap = new Bitmap( path, true );
            }
            catch { }
         }
         return retBitmap;
      }
