    [WebMethod]
    public string UploadFileBasic( string wsURL,
                                   byte[] incomingArray,
                                   string FileName,
                                   string RecordTypeName)
    {
        return UploadFile( wsUrl, incomingArray, fileName, RecordTypeName, null );
    }
     
