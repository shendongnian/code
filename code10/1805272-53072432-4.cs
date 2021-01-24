    internal static string Token(string CorpID, string Secret)
    {
        CorpID = CorpID ?? "wwe1f80304633b3";
        Secret = Secret ?? "Ev7_oVNNbTpzkfcZ_QhX9l0VjZnAQ";
    
        string token;    
        using (var wc = new WebClient())
        {
            token = wc.DownloadString($"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={CorpID}&corpsecret={Secret}");
        }
        if (token.Contains("access_token"))
        {
            return token.Split(",")[2].Split(":")[1].Replace("\"", "");
        }
        return "";
    }
