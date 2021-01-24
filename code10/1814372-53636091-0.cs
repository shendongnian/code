    public static void SignFile(string filePath,X509Certificate2 cert, string p7mFilePath)
    {
    	if (!p7mFilePath.ToLowerInvariant().EndsWith(".p7m"))
    		p7mFilePath += ".p7m";
    
    	try
    	{
    		ContentInfo content = new ContentInfo(new Oid("1.2.840.113549.1.7.1", "PKCS 7 Data"), File.ReadAllBytes(filePath));
    		SignedCms signedCms = new SignedCms(SubjectIdentifierType.IssuerAndSerialNumber, content, false);
    		CmsSigner signer = new CmsSigner(cert);
    		signer.IncludeOption = X509IncludeOption.EndCertOnly;
    		signer.DigestAlgorithm = new Oid("2.16.840.1.101.3.4.2.1", "SHA256");
    		signer.SignedAttributes.Add(new Pkcs9SigningTime(DateTime.Now));
    		try
    		{
    			//PKCS7 format
    			signedCms.ComputeSignature(signer, false);
    		}
    		catch (CryptographicException cex)
    		{
    			//To evaluate https://stackoverflow.com/a/52897100
    			/*
    			// Try re-importing the private key into a better CSP:
    			using (RSA tmpRsa = RSA.Create())
    			{
    				tmpRsa.ImportParameters(cert.GetRSAPrivateKey().ExportParameters(true));
    				using (X509Certificate2 tmpCertNoKey = new X509Certificate2(cert.RawData))
    				using (X509Certificate2 tmpCert = tmpCertNoKey.CopyWithPrivateKey(tmpRsa))
    				{
    					signer.Certificate = tmpCert;
    					signedCms.ComputeSignature(signer, false);
    				}
    			}*/
    
    			throw cex;
    		}
    		byte[] signature = signedCms.Encode();
    		File.WriteAllBytes(p7mFilePath, signature);
    	}
    	catch (Exception)
    	{
    		throw;
    	}
    	finally
    	{
    		if (File.Exists(tempFile))
    			File.Delete(tempFile);
    	}
    }
