    void Main()
    {
    	string baseFolder = @"c:\Backups";
    	string source = @"C:\Tests\Test";
    	string target = Path.Combine(baseFolder, DateTime.Now.ToString("yyyyMMddHHmmss"));
    	if (!Directory.Exists(baseFolder))
    	{
    		Directory.CreateDirectory( baseFolder );
    	}
        CopyFolder( source, target );
    }
    
    
    private void CopyFolder(string source, string destinationBase)
    {
        CopyFolder( new DirectoryInfo( source ), destinationBase );
        foreach (DirectoryInfo di in new DirectoryInfo(source).GetDirectories("*.*", SearchOption.AllDirectories))
        {
          CopyFolder( di, destinationBase );
        }
    }
    
    private void CopyFolder( DirectoryInfo di, string destinationBase )
    {
       string destinationFolderName = Path.Combine( destinationBase, di.FullName.Replace(":",""));
       if ( !Directory.Exists( destinationFolderName ) )
       {
          Directory.CreateDirectory( destinationFolderName );
       }
       foreach (FileInfo fi in di.GetFiles())
       {
          fi.CopyTo( Path.Combine(destinationFolderName, fi.Name), false);
       }
    }
