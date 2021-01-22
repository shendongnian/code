    //Define path
    //This path uses the full path of user authentication
    String path = string.Format("WinNT://{0}/{1},user", server_address, username);
    DirectoryEntry deBase = null;
    try
    {
        //Try to connect with secure connection
        deBase = new DirectoryEntry(path, username, _passwd, AuthenticationTypes.Secure);
        //Connection test
        //After test define the deBase with the parent of user (root container)
        object nativeObject = deBase.NativeObject;
        deBase = deBase.Parent;
    }
    catch (Exception ex)
    {
        //If an error occurred try without Secure Connection
        try
        {
            deBase = new DirectoryEntry(path, username, _passwd);
            //Connection test
            //After test define the deBase with the parent of user (root container)
            object nativeObject = deBase.NativeObject;
            deBase = deBase.Parent;
            nativeObject = deBase.NativeObject;
        }
        catch (Exception ex2)
        {
            //If an error occurred throw the error
            throw ex2;
        }
    }
