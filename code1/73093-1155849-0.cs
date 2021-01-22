    [WebMethod]
        public string UploadFileBasic( string wsURL
            , byte[] incomingArray
            , string FileName
            , string RecordTypeName)
    {
        return UploadFile(wsURL, incomingArray, FileName, RecordTypeName, new MetaData[0]);
    }
