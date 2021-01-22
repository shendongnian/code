    List<string> varNames = new List<string> { "return_path", "user_state" };
    
    var args = this.Request.QueryString.AllKeys
                    .Where( key => varNames.Contains( key) )
                    .Select( key => key + "=" + HttpUtility.UrlEncode(Request.QueryString[key]) );
    
    string newUrl = "/new/request/uri";
    if (args.Any())
    {
        newUrl += "?" + String.Join("&", args);
    }
    
    Response.Redirect(newUrl);
