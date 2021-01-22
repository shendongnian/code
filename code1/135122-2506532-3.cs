            public void ProcessRequest(HttpContext context)
        {
            string d = HttpContext.Current.Request.QueryString["d"]; 
            string t = HttpContext.Current.Request.QueryString["t"];
            string paramGuid = HttpContext.Current.Request.QueryString["paramGuid"];
            string urlFormatter = "http://" + HttpContext.Current.Request.Url.Host + "/WebResource.axd?d={0}&t={1)";
            // URL to resource.
            string url = string.Format(urlFormatter, d, t);
            string strResult = string.Empty;
            WebResponse objResponse;
            WebRequest objRequest = System.Net.HttpWebRequest.Create(url);
            objResponse = objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                strResult = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            DynamicScriptSessionManager sessionManager = (DynamicScriptSessionManager)HttpContext.Current.Application["DynamicScriptSessionManager"];
            DynamicClientScriptParameters parameters = null;
            foreach (var item in sessionManager)
            {
                Guid guid = new Guid(paramGuid);
                if (item.SessionID == guid)
                {
                    parameters = item.DynamicScriptParameters;
                }
            }
            foreach (var item in parameters)
            {
                strResult = strResult.Replace("$" + item.Key + "$", item.Value);
            }
            // Display results to a webpage
            context.Response.Write(strResult);
        }
