    static void Main(string[] args)
    {
    	string accessKey = "ACCESS_KEY";
    	string secretKey = "SECRET_KEY";
    	string bucketName = "BUCKET_NAME";
    	string pathToFile = "FOLDER1/FOLDER2/MyFile.txt";
        DateTime authKeyExpirationDate = DateTime.Now.AddHours(1);
    	string authenticatedDownloadLink = GenerateDownloadLink(bucketName, pathToFile, authKeyExpirationDate, accessKey, secretKey);
    	Console.WriteLine(authenticatedDownloadLink);
    	Console.Read();
    }
    
    private static string GenerateDownloadLink(string bucketName, string pathToFile, DateTime expirationDate, string accessKey, string secretKey)
    {
    	Uri downloadLink = new Uri(string.Format("https://{0}.s3.amazonaws.com/{1}", bucketName, pathToFile));
    
    	string canonicalizedResource = string.Concat("/", bucketName, "/", pathToFile);
    
    	int secondsSinceEpoch = GetSecondsSinceEpoch(expirationDate);
    	string signature = GenerateStringToSign("GET", null, null, secondsSinceEpoch, null, canonicalizedResource);
    	string str = SignSignature(signature, accessKey, secretKey);
    
    	System.Collections.Specialized.NameValueCollection nameValueCollection
    		= new System.Collections.Specialized.NameValueCollection()
    	{
    		{ "AWSAccessKeyId", accessKey },
    		{ "Signature", str },
    		{ "Expires", secondsSinceEpoch.ToString() }
    	};
    
    	StringBuilder stringBuilder = new StringBuilder();
    	int num = 0;
    	foreach (string key in nameValueCollection.Keys)
    	{
    		stringBuilder.Append(key);
    		stringBuilder.Append("=");
    		stringBuilder.Append(nameValueCollection[key]);
    		num++;
    		if (num == nameValueCollection.Keys.Count)
    		{
    			continue;
    		}
    		stringBuilder.Append("&");
    	}
    
    	UriBuilder uriBuilder = new UriBuilder(downloadLink)
    	{
    		Query = stringBuilder.ToString()
    	};
    
    	return uriBuilder.ToString();
    }
    
    private static int GetSecondsSinceEpoch(DateTime expirationDate)
    {
    	TimeSpan universalTime = expirationDate.ToUniversalTime() - new DateTime(1970, 1, 1);
    	return (int)universalTime.TotalSeconds;
    }
    
    private static string GenerateStringToSign(string httpVerb, string contentMD5, string contentType, int expires, string canonicalizedAmzHeaders, string canonicalizedResource)
    {
    	StringBuilder stringBuilder = new StringBuilder(httpVerb);
    	stringBuilder.Append("\n");
    	stringBuilder.Append(contentMD5);
    	stringBuilder.Append("\n");
    	stringBuilder.Append(contentType);
    	stringBuilder.Append("\n");
    	stringBuilder.Append(expires);
    	stringBuilder.Append("\n");
    	stringBuilder.Append(canonicalizedAmzHeaders);
    	stringBuilder.Append(canonicalizedResource);
    	return stringBuilder.ToString();
    }
    
    private static string SignSignature(string signatureToSign, string accessKey, string secretKey)
    {
    	byte[] numArray = HMACSHA1_UTF8_Hash(signatureToSign, secretKey);
    	return Uri.EscapeDataString(Base64Encode(numArray));
    }
    
    private static byte[] HMACSHA1_UTF8_Hash(string input, string key)
    {
    	byte[] numArray;
    	System.Security.Cryptography.HMACSHA1 hMACSHA1 = new System.Security.Cryptography.HMACSHA1(Encoding.UTF8.GetBytes(key));
    	using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(input)))
    	{
    		numArray = hMACSHA1.ComputeHash(memoryStream);
    	}
    	return numArray;
    }
    
    private static string Base64Encode(byte[] data)
    {
    	return Convert.ToBase64String(data);
    }
