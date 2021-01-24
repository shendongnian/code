        [OperationContract(IsOneWay = false)]
        [WebGet(UriTemplate = "GetXml/{xmlFileName}")]
        Stream GetXml(string xmlFileName);
    
         public Stream GetXml(string xmlFileName)
        {
        WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
    
        string xmlLocation=GetXmlLocation(xmlFileName);
    
        try
        {
          return File.OpenRead(xmlLocation);
        }
        catch
        {
           // File Not Found
     
           return null;
        }
     
        }
