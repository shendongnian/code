    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        if (!this.Request.Url.Host.StartsWith("www") && !this.Request.Url.IsLoopback)
        {
            var url = new UriBuilder(this.Request.Url);
            url.Host = "www." + this.Request.Url.Host;
            this.Response.RedirectPermanent(url.ToString(), endResponse: true);
        }
    }
