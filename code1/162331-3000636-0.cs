    string url = "http://www.site.com/page.aspx";
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    
    // set request properties
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    
    // set post values
    string postValues = "location=" + location.Text + "&email=" + email.Text;
    request.ContentLength = postValues.Length;
    
    // write post values
    StreamWriter streamWriter = new StreamWriter (request.GetRequestStream(), System.Text.Encoding.ASCII);
    streamWriter.Write(postValues);
    streamWriter.Close();
    // process response
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    StreamReader streamReader = new StreamReader(response.GetResponseStream());
    string responseData = streamReader.ReadToEnd();
    streamReader.Close();
    // do any processing needed on responseData...
