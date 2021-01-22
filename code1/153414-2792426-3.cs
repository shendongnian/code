    public class WebSumitter 
    { 
        public string Submit(string URL, Dictionary<string, string> Parameters, MethodType Method) 
        { 
            // Prepare Parameters String 
            var values = new System.Collections.Specialized.NameValueCollection();
            foreach (KeyValuePair<string, string> _Parameter in Parameters) 
            { 
                values.Add (_Parameter.Key, _Parameter.Value);
            } 
    
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; MSIE 6.0; Win32)"; 
            if (Method == MethodType.GET) 
            {
                UriBuilder _builder = new UriBuilder(URL);
                if (values.Count > 0) 
                    _builder.Query = ToQueryString (values);
                string _stringResults = wc.DownloadString(_builder.Uri);
                return _stringResults;
            }
            else if (Method == MethodType.POST)
            {
                byte[] _byteResults = wc.UploadValues (URL, "POST", values);
                string _stringResults = Encoding.UTF8.GetString (_byteResults);
                return _stringResults;
            }
            else
            {
                throw new NotSupportedException ("Unknown HTTP Method");
            }
        }
        private string ToQueryString(System.Collections.Specialized.NameValueCollection nvc)
        {
            return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, 
                key => string.Format("{0}={1}", System.Web.HttpUtility.UrlEncode(key), System.Web.HttpUtility.UrlEncode(nvc[key]))));
        } 
    }
