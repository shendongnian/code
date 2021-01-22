    public static string Authenticate(string pwd, string uname)
    {
        string pwd = "", uname = "";
        HttpWebRequest requestFile = (HttpWebRequest)WebRequest.Create("https://myHost.com/V1/Identity/Authenticate");
        requestFile.ContentType = "application/json";
        requestFile.Method = "POST";
        new StreamWriter(requestFile.GetRequestStream()).Write("{\"Header\":{\"AuthToken\":null,\"ProductID\":\"NOR\",\"SessToken\":null,\"Version\":1},\"ReturnAuthentication\":true,\"Password\":\"" + pwd + "\",\"Username\":\"" + uname + "\",\"ReturnCredentials\":false }'");
        HttpWebResponse serverResponse = (HttpWebResponse)requestFile.GetResponse();
        if (HttpStatusCode.OK != serverResponse.StatusCode)
            throw new Exception("Url request failed.  Connection to the server inturrupted");
        StreamReader responseStream = new StreamReader(serverResponse.GetResponseStream());
        return responseStream.ReadLine();
    }
