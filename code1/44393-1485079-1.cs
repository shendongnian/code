      private string GetWebAppRoot()
        {
            string host = (HttpContext.Current.Request.Url.IsDefaultPort) ? 
                HttpContext.Current.Request.Url.Host : 
                HttpContext.Current.Request.Url.Authority;
            host = String.Format("{0}://{1}", HttpContext.Current.Request.Url.Scheme, host);            
            if (HttpContext.Current.Request.ApplicationPath == "/")
                return host;
            else
                return host + HttpContext.Current.Request.ApplicationPath;
        }
