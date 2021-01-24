    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(strUrl);
    Request.Method = "GET";
    Request.KeepAlive = true;
    HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
    if (Response.StatusCode == HttpStatusCode.OK) {
         ....
    }
