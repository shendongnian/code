    /// <summary>
    /// Provides a filename given if it does not exist.
    /// If the filename exists, provides the lowest numeric number such that
    /// filename-number.ext does not exist.
    /// </summary>
    public static string GetNextFilename( string desiredFilename )
    {
        // using System.IO;
        int num = 0;
        FileInfo fi = new FileInfo( desiredFilename );
        
        string basename = fi.FullName.Substring( 0, fi.FullName.Length - fi.Extension.Length );
        string extension = fi.Extension;
    
        while( fi.Exists )
        {
            fi = new FileInfo( String.Format( "{0}({1}){2}",
                basename,
                i++,
                extension ) );
        }
        
        return fi.FullName; // or fi.Name;
    }
