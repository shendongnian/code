    [WebMethod]
    public static string postRootObject(Rootobject roots)
    {
        try
        {
            var objectJsonString = JsonConvert.SerializeObject(roots);
            //pass to stored procedure as 
            var statusSP = sendJsonToSqlServer("readDataFromJSON", objectJsonString);
            return "yaay it works";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
