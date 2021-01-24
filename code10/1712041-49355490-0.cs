	public void DecryptFile(string sInputFileName, string sOutputFileName, string sKey)
	{
		DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
		DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
		DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
		
		ICryptoTransform desdecrypt = DES.CreateDecryptor();
		using (FileStream fsread = new FileStream(sInputFileName, FileMode.Open, FileAccess.Read))
		using (StreamWriter fsDecrypted = new StreamWriter(sOutputFileName))
		using (CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read))
		{
			//Print result
			var buffer = new byte[1024];
            var read = cryptostreamDecr.Read(buffer, 0, buffer.Length);
            while (read > 0)
            {
                fsDecrypted.Write(buffer, 0, read);
                read = cryptostreamDecr.Read(buffer, 0, buffer.Length);
            }
		}
	}
