    private static string CreateSalt(int size)
	{
		//Generate a cryptographic random number.
		RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
		byte[] buff = new byte[size];
		rng.GetBytes(buff);
		// Return a Base64 string representation of the random number.
		return Convert.ToBase64String(buff);
	}
