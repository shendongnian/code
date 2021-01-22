    public class UploadFileAgrument 
    {
      public string wsURL;
      public byte[] incomingArray;
      public string FileName;
      public string RecordTypeName;
      public MetaData[] metaDataArray;
    }
    
    [WebMethod]
    public string UploadFile(UploadFileAgrument fileToUpload)
    {
      if(fileToUpload.metaDataArray!=null && metaDataArray.Length > 0)
      {
      }
      else
      {
      }  
    }
