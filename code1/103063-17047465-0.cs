    //Identificate separator
    string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
    //Encoding
    byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
    
    //Creation and specification of the request
    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url); //sVal is id for the webService
    wr.ContentType = "multipart/form-data; boundary=" + boundary;
    wr.Method = "POST";
    wr.KeepAlive = true;
    wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
    
    string sAuthorization = "login:password";//AUTHENTIFICATION BEGIN
    byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sAuthorization);
    string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
    wr.Headers.Add("Authorization: Basic " + returnValue); //AUTHENTIFICATION END
    Stream rs = wr.GetRequestStream();
    
    
    string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}"; //For the POST's format
    
    //Writting of the file
    rs.Write(boundarybytes, 0, boundarybytes.Length);
    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(Server.MapPath("questions.pdf"));
    rs.Write(formitembytes, 0, formitembytes.Length);
    
    rs.Write(boundarybytes, 0, boundarybytes.Length);
    
    string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
    string header = string.Format(headerTemplate, "file", "questions.pdf", contentType);
    byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
    rs.Write(headerbytes, 0, headerbytes.Length);
    
    FileStream fileStream = new FileStream(Server.MapPath("questions.pdf"), FileMode.Open, FileAccess.Read);
    byte[] buffer = new byte[4096];
    int bytesRead = 0;
    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
    {
        rs.Write(buffer, 0, bytesRead);
    }
    fileStream.Close();
    
    byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
    rs.Write(trailer, 0, trailer.Length);
    rs.Close();
    rs = null;
    
    WebResponse wresp = null;
    try
    {
        //Get the response
        wresp = wr.GetResponse();
        Stream stream2 = wresp.GetResponseStream();
        StreamReader reader2 = new StreamReader(stream2);
        string responseData = reader2.ReadToEnd();
    }
    catch (Exception ex)
    {
        string s = ex.Message;
    }
    finally
    {
        if (wresp != null)
        {
            wresp.Close();
            wresp = null;
        }
        wr = null;
    }
