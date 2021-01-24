    public string Hash(IEnumerable<int> values)
    {
	   using (var hasher = new SHA1Managed())
	   {
		var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(string.Join("-", values)));
		return BitConverter.ToString(hash).Replace("-", "");
	   }
    }
