    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Authentication error");
        context.Response.StatusCode = 401;
    }
