	using (MemoryStream ms = new MemoryStream())
	{
		using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
		{
			using (StreamWriter sw = new StreamWriter(cs)) 
			{ 
				sw.Write(Encoding.UTF8.GetBytes(plainText));
			}
		}
		encrypted = ms.ToArray();
	}
