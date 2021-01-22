    string FullApplicationPath {
        get {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}://{1}", Request.Url.Scheme, Request.Url.Host);
    
            if (!Request.Url.IsDefaultPort)
                sb.AppendFormat(":{0}", Request.Url.Port);
    
            if (!string.Equals("/", Request.ApplicationPath))
                sb.Append(Request.ApplicationPath);
    
            return sb.ToString();
        }
    }
