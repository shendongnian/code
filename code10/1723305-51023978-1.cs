       const string WEBSERVICE_URL = "https://poloniex.com/tradingApi";
        try
        {
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            if (webRequest != null)
            {
                webRequest.Method = "POST";
                webRequest.Timeout = 12000;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Headers.Add("Key", _apiKey);
                webRequest.Headers.Add("Sign", CreateSignature());     // keysecret 
                
                var postData = "&nonce=&command=returnBalances";
                var data = Encoding.ASCII.GetBytes(postData);
               
                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        var jsonResponse = sr.ReadToEnd();
                        Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
