    HttpContext.Current.Response.ContentType = "text/xml";
    HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
    
    using (TextWriter textWriter 
    	= new StreamWriter(HttpContext.Current.Response.OutputStream, Encoding.UTF8))
    {
    	XmlTextWriter writer = new XmlTextWriter(textWriter);
    	writer.WriteString(xml.ToString());
    }
