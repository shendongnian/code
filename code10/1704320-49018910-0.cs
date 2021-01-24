    HttpRequest request = HttpContext.Current.Request;
    request.InputStream.Seek(0, SeekOrigin.Begin);
    var reader = new StreamReader(request.InputStream);
    var requestFromPost = Encoding.Default.GetString(HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes));
    //this is very important to have the parameters available in the action
    request.InputStream.Seek(0, SeekOrigin.Begin);
