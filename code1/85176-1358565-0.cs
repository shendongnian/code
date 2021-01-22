	public static byte[] ComputeFileHash(string fileName)
	{
		using (var stream = File.OpenRead(fileName))
			return System.Security.Cryptography.MD5.Create().ComputeHash(stream);
	}
