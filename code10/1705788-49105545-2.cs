    var keyStore = KeyStore.GetInstance("PKCS12");
    string clientCertPassword = "password_of_certificate";
    using (var stream = Application.Context.Assets.Open("cert.pfx"))
    {
        keyStore.Load(stream, clientCertPassword.ToCharArray());
    }
    KeyManagerFactory kmf = KeyManagerFactory.GetInstance("x509");
    kmf.Init(keyStore, clientCertPassword.ToCharArray());
    IKeyManager[] keyManagers = kmf.GetKeyManagers();
    SSLContext sslContext = SSLContext.GetInstance("TLS");
    sslContext.Init(keyManagers, null, null);
    String result = null;
    HttpURLConnection urlConnection = null;
    HttpStatus lastResponseCode;
    try
    {
        URL requestedUrl = new URL("https://10.106.92.42:444");
        urlConnection = (HttpURLConnection)requestedUrl.OpenConnection();
        if (urlConnection is HttpsURLConnection) {
        ((HttpsURLConnection)urlConnection).SSLSocketFactory = sslContext.SocketFactory;
        }
        urlConnection.RequestMethod = "GET";
        urlConnection.ConnectTimeout = 1500;
        urlConnection.ReadTimeout = 1500;
                
        lastResponseCode = urlConnection.ResponseCode;
        result = ReadFully(urlConnection.InputStream);
        string lastContentType = urlConnection.ContentType;
     }
     catch (Exception ex)
     {
        result = ex.ToString();
     }
     finally
     {
        if (urlConnection != null)
        {
            urlConnection.Disconnect();
        }
     }
