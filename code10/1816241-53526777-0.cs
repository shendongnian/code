    string GenerateHmac(string input, string key)
    {
    	var inputBytes = Encoding.UTF8.GetBytes(input);
    	var keyBytes = Encoding.UTF8.GetBytes(key);
    
    	using (var memoryStream = new MemoryStream(inputBytes))
    	{
    		using (var hmacSha1 = new HMACSHA1(keyBytes))
    		{
    			return hmacSha1.ComputeHash(memoryStream).Aggregate("", 
    				(aggregator, singleByte) => aggregator + singleByte.ToString("X2"), aggregator => aggregator);
    		}
    	}
    }
    // somewhere in your code
    var value = "value";
    var secretValue = "secretValue";
    
    var hmac = GenerateHmac(value, value + secretValue);
    // hmac is "0B3A72A9AF80D0E5F2CEDDCA12EE21E90DD590DE"
