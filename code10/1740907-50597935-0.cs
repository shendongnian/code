    public static string HttpUploadFile(string file)
    {
        string paramName = "file[]";
        string[] result = null;
        string url = "http://192.168.XX.XX:XXXX";
        string contenttype_xlsx = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        string contenttype_pptx = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        string contenttype_docx = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";         
        string contentType = "";
    
        switch (Path.GetExtension(file))
        {
            case ".docx":
                contentType = contenttype_docx;
                break;
    
            case ".pptx":
                contentType = contenttype_pptx;
                break;
    
            default:
                contentType = contenttype_xlsx;
                break;
        }            
        
        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
    
        HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
        wr.ContentType = "multipart/form-data; boundary=" + boundary;
        wr.Method = "POST";
        wr.KeepAlive = true;
        wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
    
        Stream rs = wr.GetRequestStream();
        
        rs.Write(boundarybytes, 0, boundarybytes.Length);
    
        string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
        string header = string.Format(headerTemplate, paramName, Path.GetFileName(file), contentType);
        byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
        rs.Write(headerbytes, 0, headerbytes.Length);
    
        FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
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
    
        WebResponse wresp = null;
        try
        {
            wresp = wr.GetResponse();
            Stream stream2 = wresp.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2, Encoding.UTF8);
            string s = reader2.ReadToEnd();
            
            JObject obj = JObject.Parse(s);        
        }
        catch (Exception ex)
        {
            if (wresp != null)
            {
                wresp.Close();
                wresp = null;
            }
            throw new ApplicationException(ex.Message + ex.StackTrace);
        }
        finally
        {
            wr = null;
        }
    
        return obj.ToString();
    }
