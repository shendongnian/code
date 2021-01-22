    WebRequest request = WebRequest.Create(“http://webserver/site/Doclib/UploadedDocument.xml”);
    request.Credentials = CredentialCache.DefaultCredentials;
    request.Method = "PUT";
    byte[] buffer = new byte[1024];
    using (Stream stream = request.GetRequestStream())
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            dataFile.MMRXmlData.Save(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            for (int i = memoryStream.Read(buffer, 0, buffer.Length); i > 0;
                i = memoryStream.Read(buffer, 0, buffer.Length))
            {
                stream.Write(buffer, 0, i);
            }
        }
    }
 
    WebResponse response = request.GetResponse();
    response.Close();
