    static bool userexists( string strUserName ) {
        string adsPath = string.Format( @"WinNT://{0}", System.Environment.MachineName );
        using( DirectoryEntry de = new DirectoryEntry( adsPath ) ) {
            try {
                return de.Children.Find( strUserName ) != null;
            } catch( Exception e ) {
                return false;
            }
        }
    }
