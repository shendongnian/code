http://localhost:60527/WebSite1test/Default2.aspx?QueryString1=1&QuerrString2=2
    Response.Write("<br/> " + HttpContext.Current.Request.Url.Host);
    Response.Write("<br/> " + HttpContext.Current.Request.Url.Authority);
    Response.Write("<br/> " + HttpContext.Current.Request.Url.AbsolutePath);
    Response.Write("<br/> " + HttpContext.Current.Request.ApplicationPath);
    Response.Write("<br/> " + HttpContext.Current.Request.Url.AbsoluteUri);
    Response.Write("<br/> " + HttpContext.Current.Request.Url.PathAndQuery);
