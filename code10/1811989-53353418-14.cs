	static String Encrypt(string plainText, byte[] Key, byte[] IV)
	{
		string encrypted;
		using (var aes = new RijndaelManaged())
		{
			aes.Mode = CipherMode.CBC;
			aes.BlockSize = 128;
			aes.KeySize = 256;
			ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
			using (var ms = new MemoryStream())
			{
				using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write, true))
				{
					using (var sw = new StreamWriter(cs)) 
					{ 
						sw.Write(plainText);
					}
				}					
				// Calling GetBuffer() avoids the extra allocation of ToArray().
            	encrypted = Convert.ToBase64String(ms.GetBuffer(), 0, checked((int)ms.Length)); 
			}
			aes.Clear();
		}
		
		return encrypted;
	}
