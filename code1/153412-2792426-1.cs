    public class WebSumitter 
    { 
        public string Submit(string URL, Dictionary<string, string> Parameters, MethodType Method) 
        { 
            // Prepare Parameters String 
            var values = new  System.Collections.Specialized.NameValueCollection()
            foreach (KeyValuePair<string, string> _Parameter in Parameters) 
            { 
                values.Add (_Parameter.Key, _Parameter.Value);
            } 
    
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; MSIE 6.0; Win32)"; 
            string _method = Method == MethodType.POST ? "POST" : (Method == MethodType.GET ? "GET" : ""); 
            
            // TODO: if it's a GET, change the line below to build a query string and 
            // use DownloadString instead of UploadValues.
            byte[] _byteResults = wc.UploadValues (URL, _method, values);
    
            string _stringResults = Encoding.UTF8.GetString (_byteResults);
            return _stringResults;
        } 
    }
