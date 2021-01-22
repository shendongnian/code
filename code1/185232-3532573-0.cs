    X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
       
    try
    {
    	store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
    
    	X509Certificate2Collection foundCerts = store.Certificates.Find(X509FindType.FindBySubjectName, "MY CERTIFICATE SUJECT NAME", true);
    
    	if (foundCerts.Count == 0)
    	{
    		// Cert not found
    	}
    	else
    	{	
    		X509Certificate2 cert = foundCerts[0]; // Get first matching certificate
    	}
    }
    finally
    {
    	store.Close();
    }
