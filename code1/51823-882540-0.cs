    void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpContext ctx = HttpContext.Current;
       
        // encoding specified?
        if (!String.IsNullOrEmpty(Request["encoding"]))
        {
            ctx.Request.ContentEncoding = System.Text.Encoding.GetEncoding(ctx.Request["encoding"]);
        }        
    }
