        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Url.Host.StartsWith("boostcredit101.azurewebsites") && !Request.Url.IsLoopback)
            {
                Response.StatusCode = 301;
                Response.AddHeader("Location", "http://www.boostcredit101.com/");
                Response.End();
                
                return;
            }
            if (!Request.Url.Host.StartsWith("www") && !Request.Url.IsLoopback)
            {
                UriBuilder builder = new UriBuilder(Request.Url);
                builder.Host = "www." + Request.Url.Host;
                Response.StatusCode = 301;
                Response.AddHeader("Location", builder.ToString());
                Response.End();
            }
        }
