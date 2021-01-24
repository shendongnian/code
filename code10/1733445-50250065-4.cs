    [WebMethod]
    public static string GetProgress()
    {
         double progress=0;
         //Your Business Logic
         progress=56;
         return Ok(progress);
    }
