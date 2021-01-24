    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void WebHookDataRecieve() //This method is called from Amazon Simple Notification Service when we receive a bounce.
    {
     string notification = "";
     using (var stream = new MemoryStream())
     {
       var request = HttpContext.Current.Request;
       request.InputStream.Seek(0, SeekOrigin.Begin);
       request.InputStream.CopyTo(stream);
       notification = Encoding.UTF8.GetString(stream.ToArray());//All of your data will be here in JSON format.
       //Simply parse it and access the data.
       }
    }
