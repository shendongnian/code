	public static string GetSignature(string method, string url, string dt)
	{
		string apiKeySecret = "HgyfMPjFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF=";
		var hmac = new HMACSHA256(Convert.FromBase64String(apiKeySecret));
		var hashed = hmac.ComputeHash(Encoding.ASCII.GetBytes(method + url + dt));
	
		return Convert.ToBase64String(hashed);
	}
