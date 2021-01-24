    `public string Encrypt(string plainText, string publicKey)
    		{
    			UTF8Encoding ByteConverter = new UTF8Encoding();
    			using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
    			{
    				PemReader reader = new PemReader(new StringReader(publicKey));
    				object kp = reader.ReadObject();
    				csp.ImportParameters(DotNetUtilities.ToRSAParameters((kp as RsaKeyParameters)));
    				var encryptedData = csp.Encrypt(data: ByteConverter.GetBytes(plainText), padding: RSAEncryptionPadding.Pkcs1);
    				return Convert.ToBase64String(encryptedData);
    			}
    		}`
