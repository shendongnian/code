    using System.Web.Services;
     [WebMethod(EnableSession = true)]
    public static string GetSession()
    {
       return Session["CoBrowse"].ToString();
    }
