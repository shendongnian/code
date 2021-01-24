    byte[] xmlBytes = XmlDocumentToByteArray(xml);
    WebClient webclient = new WebClient
    {
          Proxy = null,
          Credentials = new NetworkCredential("test", "test")
    };
    Uri uri = new Uri("ftp://localhost/test.xml");
    webclient.UploadData(uri, xmlBytes);
