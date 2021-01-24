    strResponse = JsonConvert.SerializeObject(new { test = "Hello World" });
    
    Context.Response.Clear();
    Context.Response.ContentType = "application/json; charset=utf-8";
    Context.Response.AddHeader("content-length", (strResponse.Length).ToString());
    Context.Response.Flush();
    
    Context.Response.Write(strResponse);
