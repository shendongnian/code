     public static string MyUploader(string strFileToUpload, string strUrl)
    {
    string strFileFormName = "file";
    Uri oUri = new Uri(strUrl);
    string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
 
    // The trailing boundary string
    byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");
 
    // The post message header
    StringBuilder sb = new StringBuilder();
    sb.Append("--");
    sb.Append(strBoundary);
    sb.Append("\r\n");
    sb.Append("Content-Disposition: form-data; name=\"");
    sb.Append(strFileFormName);
    sb.Append("\"; filename=\"");
    sb.Append(Path.GetFileName(strFileToUpload));
    sb.Append("\"");
    sb.Append("\r\n");
    sb.Append("Content-Type: ");
    sb.Append("application/octet-stream");
    sb.Append("\r\n");
    sb.Append("\r\n");
    string strPostHeader = sb.ToString();
    byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);
 
    // The WebRequest
    HttpWebRequest oWebrequest = (HttpWebRequest)WebRequest.Create(oUri);
    oWebrequest.ContentType = "multipart/form-data; boundary=" + strBoundary;
    oWebrequest.Method = "POST";
 
    // This is important, otherwise the whole file will be read to memory anyway...
    oWebrequest.AllowWriteStreamBuffering = false;
 
    // Get a FileStream and set the final properties of the WebRequest
    FileStream oFileStream = new FileStream(strFileToUpload, FileMode.Open, FileAccess.Read);
    long length = postHeaderBytes.Length + oFileStream.Length + boundaryBytes.Length;
    oWebrequest.ContentLength = length;
    Stream oRequestStream = oWebrequest.GetRequestStream();
 
    // Write the post header
    oRequestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
 
    // Stream the file contents in small pieces (4096 bytes, max).
    byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)oFileStream.Length))];
    int bytesRead = 0;
    while ((bytesRead = oFileStream.Read(buffer, 0, buffer.Length)) != 0)
        oRequestStream.Write(buffer, 0, bytesRead);
    oFileStream.Close();
 
    // Add the trailing boundary
    oRequestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
    WebResponse oWResponse = oWebrequest.GetResponse();
    Stream s = oWResponse.GetResponseStream();
    StreamReader sr = new StreamReader(s);
    String sReturnString = sr.ReadToEnd();
 
    // Clean up
    oFileStream.Close();
    oRequestStream.Close();
    s.Close();
    sr.Close();
 
    return sReturnString;
    }
