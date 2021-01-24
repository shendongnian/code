    internal  HttpWebRequest CreateWebRequest(string url, string action)
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Headers.Add("SOAPAction", action);
                var username = "xxxxx";
                var password = "xxxxx";
    
    
                byte[] credentialBuffer = new UTF8Encoding().GetBytes(
                        username + ":" +
                        password);
                webRequest.Headers["Authorization"] =
                        "Basic " + Convert.ToBase64String(credentialBuffer);
    
                webRequest.PreAuthenticate = true;
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
    
                webRequest.Method = "POST";
                return webRequest;
            }
