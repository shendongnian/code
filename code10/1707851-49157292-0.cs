        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Context.Request.Headers.AllKeys.Contains("Origin"))
            {
                Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:57062");
                Context.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, PATCH, OPTIONS");
                Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
                if (Context.Request.HttpMethod == "OPTIONS") Context.Response.End();
            }
        }
        
