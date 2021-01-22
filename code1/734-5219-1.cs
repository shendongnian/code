    public static void PassthroughAuthentication()
    {
        System.Web.HttpContext.Current.Response.Write("<body 
        onload=document.forms[0].submit();window.location=\"Home.aspx\";>");
        
        System.Web.HttpContext.Current.Response.Write("<form name=\"Form\" 
        target=_blank method=post 
        action=\"https://external-url.com/security.asp\">");
        System.Web.HttpContext.Current.Response.Write(string.Format("<input 
           type=hidden name=\"cFName\" value=\"{0}\">", "Username"));
        System.Web.HttpContext.Current.Response.Write("</form>");
        System.Web.HttpContext.Current.Response.Write("</body>");
    }
