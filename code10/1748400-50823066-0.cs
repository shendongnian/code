	public static string GetSignature(string method, string url, string dt)
	{
		string apiKeySecret = "HgyfMPjFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF=";
        var encoding = new ASCIIEncoding();
        var canonicalRequest = string.Format("{0}{1}{2}", method, url, dt);
        var key = Convert.FromBase64String(apiKeySecret);	
        var hmac = new HMACSHA256(key);
        var hashed = hmac.ComputeHash(encoding.GetBytes(canonicalRequest));	
        return Convert.ToBase64String(hashed);
	}
