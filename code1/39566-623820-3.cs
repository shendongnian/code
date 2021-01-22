    //add a username Cookie
    Response.Cookies["userName"].Value = "EvilBoy";
    Response.Cookies["userName"].Expires = DateTime.Now.AddDays(10);
    //Can Limit a cookie to a certain Domain
    Response.Cookies["domain"].Domain = "Stackoverflow.com";
    //request a username cookie
    if(Request.Cookies["userName"] != null)
       lblUserName.Text = Server.HtmlEncode(Request.Cookies["userName"].Value);
