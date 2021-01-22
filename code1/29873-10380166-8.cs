    /// <remarks>
    /// This function only works for byte arrays encoded by <see cref="GetBytes"/>
    /// </remarks>
	static string GetString(byte[] bytes)
	{
		char[] chars = new char[bytes.Length / sizeof(char)];
		System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
		return new string(chars);
	}
