    public static string getCEUserToken(string baseURL, string uid, string pwd)
    {
        string UserToken = "";
        System.Net.WebRequest request = System.Net.WebRequest.Create(baseURL +      "/setCredentials?op=getUserToken&userId=" + uid + "&password=" + pwd +
        "&verify=true");
        request.Method = "POST";
        System.Net.WebResponse response = request.GetResponse();
        Stream stream = response.GetResponseStream();
        byte[] token = new byte[response.ContentLength];
        stream.Read(token, 0, (int)response.ContentLength);
        response.Close();
        foreach (byte chr in token)
            UserToken += System.Convert.ToChar(chr);
        return System.Web.HttpUtility.UrlEncode(UserToken);
    }
