    [WebMethod]
    public static string postRootObject(Rootobject roots)
    {
       try
       {                
           var objectXML = serializeListtoXML<Rootobject>(roots); //converting the given object into an xml string
           //passing the data to stored procedure as 
           var statusSP = sendXMLToSqlServer("readDataFromXML", objectXML);
           return "yaaay it works";
       }
       catch (Exception ex)
       {
           throw ex;
       }
    }
