    string HttpPost (string uri, string parameters)
    { 
       // parameters: name1=value1&name2=value2	
       WebRequest webRequest = WebRequest.Create (uri);
       webRequest.ContentType = "application/x-www-form-urlencoded";
       webRequest.Method = "POST";
       byte[] bytes = Encoding.ASCII.GetBytes (parameters);
       Stream os = null;
       try
       { // send the Post
          webRequest.ContentLength = bytes.Length;   //Count bytes to send
          os = webRequest.GetRequestStream();
          os.Write (bytes, 0, bytes.Length);         //Send it
       }
       catch (WebException ex)
       {
          MessageBox.Show ( ex.Message, "HttpPost: Request error", 
             MessageBoxButtons.OK, MessageBoxIcon.Error );
       }
       finally
       {
          if (os != null)
          {
             os.Close();
          }
       }
     
       try
       { // get the response
          WebResponse webResponse = webRequest.GetResponse();
          if (webResponse == null) 
             { return null; }
          StreamReader sr = new StreamReader (webResponse.GetResponseStream());
          return sr.ReadToEnd ().Trim ();
       }
       catch (WebException ex)
       {
          MessageBox.Show ( ex.Message, "HttpPost: Response error", 
             MessageBoxButtons.OK, MessageBoxIcon.Error );
       }
       return null;
    } // end HttpPost 
