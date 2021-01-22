    // Setting cookie : 
    Response.Cookies["UserName"].Value = "Erhan";
    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(7); // Persists 1 week
    
    // Getting cookie : 
    string username = string.Empty;
    if(Request.Cookies["UserName"] != null)
    {
        username = Server.HtmlEncode(Request.Cookies["UserName"].Value);
    }
