    static public void CopyFolder( string sourceFolder, string destFolder )
    {
         if (!Directory.Exists( destFolder ))
         Directory.CreateDirectory( destFolder );
         string[] files = Directory.GetFiles( sourceFolder );
         foreach (string file in files)
         {
            string name = Path.GetFileName( file );
            string dest = Path.Combine( destFolder, name );
            File.Copy( file, dest );
         }
         string[] folders = Directory.GetDirectories( sourceFolder );
         foreach (string folder in folders)
         {
             string name = Path.GetFileName( folder );
             string dest = Path.Combine( destFolder, name );
             CopyFolder( folder, dest );
       }
 }
