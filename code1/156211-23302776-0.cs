    WebRequest webRequest = WebRequest.Create(@"https://myservice/path");
    webRequest.ContentType = "text/html";
    webRequest.Method = "POST";
    string body = "...";
    byte[] bytes = Encoding.ASCII.GetBytes(body);
    webRequest.ContentLength = bytes.Length;
    var os = webRequest.GetRequestStream();
    os.Write(bytes, 0, bytes.Length);
    os.Close();
    webRequest.Timeout = 0; //setting the timeout to 0 causes the request to fail
    WebResponse webResponse = webRequest.GetResponse(); //Exception thrown here ...
