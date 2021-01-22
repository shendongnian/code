    /// <summary>
    /// Extracts an RSA public key from a signed assembly
    /// </summary>
    /// <param name="assembly">Signed assembly to extract the key from</param>
    /// <returns>RSA Crypto Service Provider initialised with the public key from the assembly</returns>
    private RSACryptoServiceProvider GetPublicKeyFromAssembly(Assembly assembly)
    {
    	// Extract public key - note that public key stored in assembly has an extra 3 headers
    	// (12 bytes) at the front that are not part of a CAPI public key blob, so they must be removed
    	byte[] rawPublicKeyData = assembly.GetName().GetPublicKey();
    
    	int extraHeadersLen = 12;
    	int bytesToRead = rawPublicKeyData.Length - extraHeadersLen;
    	byte[] publicKeyData = new byte[bytesToRead];
    	Buffer.BlockCopy(rawPublicKeyData, extraHeadersLen, publicKeyData, 0, bytesToRead);
    
    	RSACryptoServiceProvider publicKey = new RSACryptoServiceProvider();
    	publicKey.ImportCspBlob(publicKeyData);
    
    	return publicKey;
    }
