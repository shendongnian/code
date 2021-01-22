    public void FindUNCPaths()
    {
       DriveInfo[] dis = DriveInfo.GetDrives();
       foreach( DriveInfo di in dis )
       {
          if(di.DriveType == DriveType.Network)
          {
             DirectoryInfo dir = di.RootDirectory;
             // "x:"
             MessageBox.Show( GetUNCPath( dir.FullName.Substring( 0, 2 ) ) );
          }
       }
    }
    
    public string GetUNCPath(string path)
    {
       if(path.StartsWith(@"\\")) 
       {
          return path;
       }
    
       ManagementObject mo = new ManagementObject();
       mo.Path = new ManagementPath( String.Format( "Win32_LogicalDisk='{0}'", path ) );
    
       // DriveType 4 = Network Drive
       if(Convert.ToUInt32(mo["DriveType"]) == 4 )
       {
          return Convert.ToString(mo["ProviderName"]);
       }
       else 
       {
          return path;
       }
    }
