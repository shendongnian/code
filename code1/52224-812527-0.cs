    var message = Collection.CreateNewMessage("FileDownloading")
    
    try
    {
        WebClass.DownloadAFile("You Know This File Is Great.XML");
    }
    finally
    {
        message.HowLongHaveIBeenAlive();
    }
