    public List<string> GetDirectories( string searchPath )
    {
        using ( WindowsImpersonationContext wic = GetIdentity().Impersonate() )
        {
            var directories = new List<string>();
    
            var di = new DirectoryInfo( searchPath );
            directories.AddRange( di.GetDirectories().Select( d => d.FullName ) );
    
            return directories;
        }
    }
