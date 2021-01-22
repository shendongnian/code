    private HttpCookie GetCookie()
    {
        // based on the php example at http://developers.facebook.com/docs/guides/canvas/#canvas
        HttpCookie cookie = Request.Cookies["fbs_" + FacebookClientId];
        if (cookie != null)
        {
            var pairs = from pair in cookie.Value.Trim('"', '\\').Split('&')
                        let indexOfEquals = pair.IndexOf('=')
                        orderby pair
                        select new
                                   {
                                       Key = pair.Substring(0, indexOfEquals).Trim(),
                                       Value = pair.Substring(indexOfEquals + 1).Trim()
                                   };
    
            IDictionary<string, string> cookieValues =
                pairs.ToDictionary(pair => pair.Key, pair => Server.UrlDecode(pair.Value));
    
            StringBuilder payload = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in cookieValues)
            {
                Response.Write(pair.Key + ": " + pair.Value + "<br/>\n");
    
                if (pair.Key != "sig")
                {
                    payload.Append(pair.Key + "=" + pair.Value);
                }
            }
    
            string sig = cookieValues["sig"];
            string hash = GetMd5Hash(payload + FacebookSecret);
    
            if (sig == hash)
            {
                return cookie;
            }
        }
    
        return null;
    }
    
    private static string GetMd5Hash(string input)
    {
        MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.Default.GetBytes(input);
        byte[] hash = cryptoServiceProvider.ComputeHash(bytes);
    
        StringBuilder s = new StringBuilder();
        foreach (byte b in hash)
        {
            s.Append(b.ToString("x2"));
        }
    
        return s.ToString();
    }
