     protected void Application_BeginRequest()
                {
    				Context.Response.AddHeader("Access-Control-Allow-Origin", ORIGINS);
    				Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
                    if (Context.Request.HttpMethod == "OPTIONS")
                    {                    
                        Context.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                        Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST PUT, DELETE, OPTIONS");                    
                        Context.Response.End();
                    }
                }
