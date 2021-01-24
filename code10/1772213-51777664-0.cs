    public HttpResponseMessage Get()
    {
      //process the request 
      .........
    
      string XML="<note><body>Message content</body></note>";
      return new HttpResponseMessage() 
      { 
        Content = new StringContent(XML, Encoding.UTF8, "application/xml") 
      };
    }
