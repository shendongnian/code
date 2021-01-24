    [WebMethod()]
    [ScriptMethod(UseHttpGet = false)]
    public static string IsWindowOpen()
    {
        string isWindowOpen = HttpContext.Current.Session["WINDOW_STATUS"] != null ? HttpContext.Current.Session["WINDOW_STATUS"].ToString() : "CLOSED";
    
        return "IsWindowOpen:" + isWindowOpen;
    }
