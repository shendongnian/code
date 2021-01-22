    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webRequest.URL);
    request.UserAgent = UserAgent;
    request.ContentType = ContentType;
    request.Method = "POST";
    // Write your bytes of the login section here
     Stream oStream = request.GetRequestStream();
     oStream.Write(webRequest.BytesToWrite, 0, webRequest.BytesToWrite.Length);
     oStream.Close();
     // Send the request and get a response
     HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
     // Read the response
     StreamReader sr = new StreamReader(resp.GetResponseStream());
     // return the response to the screen
     string returnedValue = sr.ReadToEnd();
      sr.Close();
      resp.Close();
      Response.Write(returnedValue);
