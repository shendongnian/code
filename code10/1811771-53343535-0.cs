    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void getJson()
    {
        DataTable data = "SELECT * FROM AT_MasterData Order by [Order]".fwSqlFillDataTable();
    
        string strResponse = JsonConvert.SerializeObject(data);
    
        Context.Response.Clear();
        Context.Response.ContentType = "application/json; charset=utf-8";
        Context.Response.AddHeader("content-length", (strResponse.Length + 1).ToString());
        Context.Response.Flush();
    
        Context.Response.Write(strResponse);
    }
