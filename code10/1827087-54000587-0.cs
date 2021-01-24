    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpContext urlRequestContext = HttpContext.Current;
        
        if (!(urlRequestContext.Request.Url.AbsolutePath.ToLower().StartsWith("/errorpages/")))
        {
            try
            {
                string hostingAuth = urlRequestContext.Request.Headers.GetValues("hostingauth").FirstOrDefault();
                
                if (hostingAuth == "company2secret")
                {
                    string newHost = "company2internal.validdomain.com";
                    reverseProxy.ProcessRequest(urlRequestContext, newHost);
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                // ignore it
            }
            catch (Exception ex)
            {
                Response.Redirect("/errorpages/missingtoken.aspx", true);
            }
        }
    }
