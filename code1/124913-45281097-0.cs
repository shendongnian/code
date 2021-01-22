    static void WriteUnderlyingResponse(Exception exception)
    {
    	do
    	{
    		if (exception.GetType() == typeof(WebException))
    		{
    			var webException = (WebException)exception;
    			using (var writer = new StreamReader(webException.Response.GetResponseStream()))
    				Console.WriteLine(writer.ReadToEnd());
    		}
    		exception = exception?.InnerException;
    	}
    	while (exception != null);
    }
