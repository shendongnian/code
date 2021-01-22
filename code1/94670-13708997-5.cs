        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
        request.Credentials = new NetworkCredential(userName, password);
        request.EnableSsl = true;
        //ServicePointManager.ServerCertificateValidationCallback = ServicePointManager_ServerCertificateValidationCallback;
        X509Certificate cert = X509Certificate.CreateFromCertFile(@"C:\MyCertDir\MyCertFile.cer");
        X509CertificateCollection certCollection = new X509CertificateCollection();
        certCollection.Add(cert);
                    
        request.ClientCertificates = certCollection;
