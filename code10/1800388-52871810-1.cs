	private string ToBase64(string path)
	{
		if (System.IO.File.Exists(path))
		{
			Byte[] bytes = System.IO.File.ReadAllBytes(path);
			return Convert.ToBase64String(bytes);
		}
		return "";
	}
