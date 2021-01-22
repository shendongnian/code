    WebRequest req = WebRequest.Create(url);
    WebResponse resp = req.GetResponse();
    String contentType = resp.ContentType;
    
    if(contentType == "text/xml")
      processXML(resp.GetResponseStream());
    else if(contentType == "text/html")
      processHTML(resp.GetResponseStream());
    else
      // process error condition
