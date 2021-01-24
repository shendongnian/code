    private static X509Certificate2 LoadCertificate(string p_storeName, string p_storeLocation, string p_Host, string p_FilePath, string p_Password, IHostingEnvironment environment)
    {
      if (p_storeName != "" && p_storeLocation != "")
      {
          using (var store = new X509Store(p_storeName, Enum.Parse<StoreLocation>(p_storeLocation)))
           {
               store.Open(OpenFlags.ReadOnly);
            
                bool validOnly = false;
                if (environment.IsDevelopment() == true) { validOnly = false; }
                else
                {
                    if (p_Host == "localhost") { validOnly = false; }
                    else { validOnly = true; }
                }
            
                var certificate = store.Certificates.Find(
                X509FindType.FindBySubjectName,p_Host,validOnly: validOnly);
            
                if (certificate.Count == 0)
                {
                    throw new InvalidOperationException($"Certificate not found for {p_Host}.");
                }
                     return certificate[0];
                }
           }
            
           if (p_FilePath != "" && p_Password != "")
           {
              return new X509Certificate2(p_FilePath, p_Password);
           }
           throw new InvalidOperationException("No valid certificate configuration found for the current endpoint.");
        }
