    string textFileContents = System.IO.File.ReadAllText( @"C:\MyFolder\MyFile.txt" );
    
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create( "http://www.myserver.com/myurl.aspx" );
    request.Method = "POST";
    ASCIIEncoding encoding = new ASCIIEncoding();
    
    string postData = "fileContents=" + System.Web.HttpUtility.UrlEncode( textFileContents );
    byte[] data = encoding.GetBytes( postData );
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = data.Length;
    Stream dataStream = request.GetRequestStream();
    dataStream.Write( data, 0, data.Length );
    dataStream.Close();
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    // do something with the response if required
