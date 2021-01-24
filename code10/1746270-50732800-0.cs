    using(var webClient = new WebClient())
    {
        webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes("clientId" + ":" + "clientSecret")));
        webClient.UploadString("https//auth.something.com","PUT","{ \"data\":\"dummy data\" }");    
    }
