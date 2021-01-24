    public static string GetSasToken(string resourceUri, string keyName, string key, TimeSpan ttl)
      {
             var expiry = GetExpiry(ttl);
             string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
             HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
             var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
             var sasToken = string.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
             HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, keyName);
             return sasToken;
     }
    
    private static string GetExpiry(TimeSpan ttl)
    {
      TimeSpan expirySinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1) + ttl;
       return Convert.ToString((int)expirySinceEpoch.TotalSeconds);
     }
