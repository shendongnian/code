    public class NameValue
    {
       public string Name{get;set;}
       public string Value{get;set;}
    }
    
    [WebMethod]
    public string UploadFile(byte[] incomingArray
        , string FileName
        , long FileLengthInBytes
        , NameValue[] nvcMetaData)
