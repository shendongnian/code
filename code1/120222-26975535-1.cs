    [WebMethod]
    public static void GetDocuments()
    {
        HttpContext.Current.Response.ContentType = "application/json";
        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(repository.GetDocuments()));
        HttpContext.Current.Response.End();
    }
