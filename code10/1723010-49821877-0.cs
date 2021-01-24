    void Start()
    {
        string nonce = DateTime.Now.ToString("HHmmss");
        string myParam = "command=returnBalances&nonce=" + nonce;
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
                webRequest.Headers.Add("Sign", genHMAC(myParam));
                byte[] dataStream = Encoding.UTF8.GetBytes($"command=returnBalances&nonce={nonce.ToString()}");
                webRequest.ContentLength = dataStream.Length;
                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(dataStream, 0, dataStream.Length);
                newStream.Close();
                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        var jsonResponse = sr.ReadToEnd();
                        OutputText.text = jsonResponse.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            OutputText.text = ex.ToString();
        }
    }
