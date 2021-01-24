    X509Store store = new X509Store(StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly);
    X509Certificate2Collection Certificate2Collection = store.Certificates;
    X509Certificate2Collection results = 
        Certificate2Collection.Find(X509FindType.FindBySubjectName, (object)subject, false);
    X509Certificate2 cert = results[0];
    Microsoft.Web.Services2.Security.X509.X509Certificate cert = 
        new Microsoft.Web.Services2.Security.X509.X509Certificate(cert.Export(X509ContentType.Cert));
