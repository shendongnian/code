    [WebMethod()]
    [ScriptMethod(UseHttpGet = false)]
    public static string SetClosingWndow()
    {
    	HttpContext.Current.Session["WINDOW_STATUS"] = "CLOSED";
    	ScriptManager.RegisterClientScriptBlock((Page)(HttpContext.Current.Handler), typeof(Page), "closePage", "window.close();", true);
    	return "Status:" + HttpContext.Current.Session["WINDOW_STATUS"];
    }
