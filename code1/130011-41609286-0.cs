    /// <summary>
	/// MD5withRSA Signing
	/// https://www.vrast.cn
	/// keyle_xiao 2017.1.12
	/// </summary>
	public class MD5withRSASigning
	{
		public Encoding encoding = Encoding.UTF8;
		public string SignerSymbol = "MD5withRSA";
		public MD5withRSASigning() { }
		public MD5withRSASigning(Encoding e, string s)
		{
			encoding = e;
			SignerSymbol = s;
		}
		private AsymmetricKeyParameter CreateKEY(bool isPrivate, string key)
		{
			byte[] keyInfoByte = Convert.FromBase64String(key);
			if (isPrivate)
				return PrivateKeyFactory.CreateKey(keyInfoByte);
			else
				return PublicKeyFactory.CreateKey(keyInfoByte);
		}
		public string Sign(string content, string privatekey)
		{
			ISigner sig = SignerUtilities.GetSigner(SignerSymbol);
			sig.Init(true, CreateKEY(true, privatekey));
			var bytes = encoding.GetBytes(content);
			sig.BlockUpdate(bytes, 0, bytes.Length);
			byte[] signature = sig.GenerateSignature();
			/* Base 64 encode the sig so its 8-bit clean */
			var signedString = Convert.ToBase64String(signature);
			return signedString;
		}
		public bool Verify(string content, string signData, string publickey)
		{
			ISigner signer = SignerUtilities.GetSigner(SignerSymbol);
			signer.Init(false, CreateKEY(false, publickey));
			var expectedSig = Convert.FromBase64String(signData);
			/* Get the bytes to be signed from the string */
			var msgBytes = encoding.GetBytes(content);
			/* Calculate the signature and see if it matches */
			signer.BlockUpdate(msgBytes, 0, msgBytes.Length);
			return signer.VerifySignature(expectedSig);
		}
	}
	
