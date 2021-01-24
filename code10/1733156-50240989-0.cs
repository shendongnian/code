    var basicResponse = new BasicResponse { Valid = false; Messages = new string[] { "not valid" } };
    var response = JsonConvert.SerializeObject(basicResponse);
    
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
    HttpContext.Current.Response.Write(response);
    HttpContext.Current.Response.End();
