    [WebMethod]
    public string UploadFileBasic( string wsURL,
                                   byte[] incomingArray,
                                   string FileName,
                                   string RecordTypeName)
    {
        return UploadFileBasic( wsUrl, incomingArray, fileName, RecordTypeName, null );
    }
     
