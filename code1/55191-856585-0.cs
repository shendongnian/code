    using System.Web.Services;
    [WebMethod]
    public static string GetSession()
    {
       return Session["CoBrowse"].ToString();
    }
