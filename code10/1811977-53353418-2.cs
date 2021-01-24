	static String Encrypt(string plainText, byte[] Key, byte[] IV)
	{
		Byte[] encrypted;
		using (var aes = new RijndaelManaged())
		{
			aes.Mode = CipherMode.CBC;
			aes.BlockSize = 128;
			aes.KeySize = 256;
			ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
			using (var ms = new MemoryStream())
			{
				using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
				{
					using (var sw = new StreamWriter(cs)) 
					{ 
						sw.Write(plainText);
					}
				}
				encrypted = ms.ToArray();
			}
			aes.Clear();
		}
		return  Convert.ToBase64String(encrypted);
	}
