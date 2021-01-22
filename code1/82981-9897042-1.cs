    [System.Web.Services.WebMethod]
    public static string CargueFinalizo()
    {
        //Whatever you need
        return HttpContext.Current.Session["ResultadoCarguePanel"] != null ? "SI" : "NO";
    }
