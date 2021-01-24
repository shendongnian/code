    string postContent = "";
    HttpContext.Current.Request.InputStream.Position = 0;
    using (var reader = new StreamReader(Request.InputStream, 
    System.Text.Encoding.UTF8, true, 4096, true))
    {
    	if (HttpContext.Current.Request.ContentLength > 0)
    	{
    		postContent = reader.ReadToEnd();
    	}
    }
                   
