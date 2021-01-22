    public void ProcessRequest (HttpContext context) {
        if (context.Request.RawUrl.ToLower().Trim().IndexOf(".ashx") != -1) context.Response.Redirect(context.Request.RawUrl.Replace(".ashx", ".esp"));
        context.Response.AddHeader("Cache-Control", "no-cache");
		context.Response.ContentType = "text/xml; charset=utf-8";
        Edwin.Web.BlogManager.Instance.GetRss(20).Save(context.Response.OutputStream);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
