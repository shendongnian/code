    private static readonly MetaData[] EmptyMetaData = new MetaData[0];
    [WebMethod]
    public string UploadFile(string wsURL
        , byte[] incomingArray
        , string fileName
        , string recordTypeName)
    {
        return UploadFile(wsURL, incomingArray, fileName, recordTypeName, EmptyMetaData)
    }
