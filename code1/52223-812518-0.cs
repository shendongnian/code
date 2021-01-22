    try 
    {
        var message = Collection.CreateNewMessage("FileDownlading"); 
        //...
        WebClass.DownloadAFile("You Know This File Is Great.XML");
    }
    finally 
    {
        //You can change this to do logging instead.
        message.Dispose(); 
    }
