    public IHttpActionResult MyControllerMedhod()
    {
    	return MySecondMethod();
    }
    private HttpResponseMessage MySecondMethod()
    {
	    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
	    FileStream stream = new FileStream("c:\temp\tester.dat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
	    result.Content = new ThrottledStream(stream, 153600);
	    result.Content.Headers.ContentDisposition = new 
        ContentDispositionHeaderValue("attachment");
	    result.Content.Headers.ContentDisposition.FileName = "c:\temp\tester.dat";
	    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
	    result.Content.Headers.ContentLength = stream.Length;
	    return result;
    }
