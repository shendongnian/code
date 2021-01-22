    var context = System.Web.HttpContext.Current; 
    context.Response.Cookies["ssocookies"].Domain = context.Request.ServerVariables["SERVER_NAME"].ToString().ToLower();
    context.Response.Cookies["ssocookies"].Value = "";
    context.Response.Cookies["ssocookies"].Path = "~/";
    context.Response.Cookies["ssocookies"].Expires = DateTime.Now.AddDays(-1);
