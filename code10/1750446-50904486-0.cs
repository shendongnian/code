    private void Application_BeginRequest(object sender, EventArgs e)
    {
    if (System.IO.File.Exists(Request.PhysicalPath))
        {
            // Do nothing here, just serve the file
        }
        // If the file does not exist then
        else if (!System.IO.File.Exists(Request.PhysicalPath))
        {
            if (Request.ServerVariables["URL"].ToString() != "/")
            {
                // Get the URL requested by the user
                string sRequestedURL = Request.Path;
                     
                string varurl = Request.ServerVariables["URL"].ToString().ToLower();
                string sTargetURL = "";
                if (varurl.Contains("/certifications/"))
                {
                    sTargetURL = "~/Erroot/details.aspx?url=" + varurl;
                }
               
                if(sTargetURL!="")
                Context.RewritePath(sTargetURL, false);
            }
        }
    }
