    public static string GetRedirectUrl(string url)
    {
         HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(url);
         request.AllowAutoRedirect = false;
         using (HttpWebResponse response = HttpWebResponse)request.GetResponse())
         {
             return response.Headers["Location"];
         }
    }
