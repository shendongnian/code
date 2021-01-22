    HttpWebRequest oRequest = null;
    oRequest = (HttpWebRequest)HttpWebRequest.Create(oURL.URL);
    oRequest.ContentType = "multipart/form-data";						
    oRequest.Method = "POST";
    PostData pData = new PostData();
    
    byte[] buffer = encoding.GetBytes(pData.GetPostData());
    
    // Set content length of our data
    oRequest.ContentLength = buffer.Length;
    
    // Dump our buffered postdata to the stream, booyah
    oStream = oRequest.GetRequestStream();
    oStream.Write(buffer, 0, buffer.Length);
    oStream.Close();
    
    // get the response
    oResponse = (HttpWebResponse)oRequest.GetResponse();
