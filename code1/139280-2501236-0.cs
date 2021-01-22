    private string HtmlPageInToString()
    {
    WebRequest myRequest;
    myRequest = WebRequest.Create(@"http://yoururlhere/");
    
    myRequest.UseDefaultCredentials = true;
    
    WebResponse myResponse = myRequest.GetResponse();
    
    Stream ReceiveStream = myResponse.GetResponseStream();
    Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
    
    StreamReader readStream = new StreamReader(ReceiveStream, encode);
    
    return readStream.ReadToEnd();
    }
