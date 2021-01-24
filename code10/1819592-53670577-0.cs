    private byte[] GetDerivedKey(X509Certificate2 publicCertificate, X509Certificate2 privateCertificate)
    {
    	byte[] derivedKey;
    
    	using (var privateKey = privateCertificate.GetECDsaPrivateKey())
    	using (var publicKey = privateCertificate.GetECDsaPublicKey())
    	{
    		var myPrivateKeyToMessWith = privateKey as ECDsaCng;
    
    		// start - taken from https://stackoverflow.com/q/48542233/3245057 
    		// make private key exportable:
    		byte[] bytes = BitConverter.GetBytes((int)(CngExportPolicies.AllowExport | CngExportPolicies.AllowPlaintextExport));
    		CngProperty pty = new CngProperty(NCryptExportPolicyProperty, bytes, CngPropertyOptions.Persist);
    		myPrivateKeyToMessWith.Key.SetProperty(pty);
    		// end - taken from https://stackoverflow.com/q/48542233/3245057
    
    		var privateParams = myPrivateKeyToMessWith.ExportParameters(true);  //This line is NOT failing anymore
    		var publicParams = publicKey.ExportParameters(false);
    
    		using (var privateCng = ECDiffieHellmanCng.Create(privateParams))
    		using (var publicCng = ECDiffieHellmanCng.Create(publicParams))
    		{
    			derivedKey = privateCng.DeriveKeyMaterial(publicCng.PublicKey);
    		}
    	}
    
    	return derivedKey;
    }
