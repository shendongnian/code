    internal static class GetStaffList
    {
        //this doesn't seem to be used right now
        internal const string ErrCode = "\"errcode\":0,\"errmsg\":\"ok\"";
    
        internal static void Token(string CorpID, string Secret)
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
                token = token.Split(",")[2].Split(":")[1].Replace("\"", "");
                MainPage.TxtToken.Text = token;
            }
            else 
            {
                token = ""; 
            }
        }
    }
