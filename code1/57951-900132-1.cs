    //Cert Challenge URL 
    Uri requestURI = new Uri("https://someurl");
    //Create the Request Object
    HttpWebRequest pageRequest = (HttpWebRequest)WebRequest.Create(requestURI);
    //After installing the cert on the server export a client cert to the working directory as Foo.cer
    string certFile = MapPath("Foo.cer");
    X509Certificate cert = X509Certificate.CreateFromCertFile(certFile);
            
    //Set the Request Object parameters
    pageRequest.ContentType = "application/x-www-form-urlencoded";
    pageRequest.Method = "POST";
    pageRequest.AllowWriteStreamBuffering = false;
    pageRequest.AllowAutoRedirect = false;
    pageRequest.ClientCertificates.Add(cert);
