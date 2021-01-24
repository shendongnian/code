	public static void Main()
	{
		string method = "GET";
		string url = "https://news-api.apple.com/channels/cdb737aa-FFFF-FFFF-FFFF-FFFFFFFFFFFF";
		string dateString = "2018-06-12T18:15:45Z";
		string apiKeySecret = "HgyfMPjFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF=";
		var MyResult = GetSignature(method, url, dateString, apiKeySecret);
		var DocumentedResult = "f3cOzwH7HGYPg481noBFwKgVOGAhH3jy7LQ75jVignA=";
		
		Console.WriteLine(MyResult);
	    Console.WriteLine(MyResult == DocumentedResult);
	}
	public static string GetSignature(string method, string url, string dt, string APISecret)
	{
		var hmac = new HMACSHA256(Convert.FromBase64String(APISecret));
		var hashed = hmac.ComputeHash(Encoding.ASCII.GetBytes(method + url + dt));
	
		return Convert.ToBase64String(hashed);
	}
