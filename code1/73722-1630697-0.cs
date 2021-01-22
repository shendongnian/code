    using Rebex.Net;
        
    // create client and connect  
    Sftp client = new Sftp();
    client.Connect(hostname);
    client.Login(username, password);
    
    // delete the file
    client.DeleteFile("/path/to/the/file");
    
    // disconnect  
    client.Disconnect();
