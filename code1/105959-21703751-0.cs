    public static string MD5Of(string text)
    {
    	return MD5Of(text, Encoding.Default);
    }
    public static string MD5Of(string text, Encoding enc)
    {
    	return HashOf<MD5CryptoServiceProvider>(text, enc);
    }
    public static string SHA1Of(string text)
    {
    	return SHA1Of(text, Encoding.Default);
    }
    public static string SHA1Of(string text, Encoding enc)
    {
    	return HashOf<SHA1CryptoServiceProvider>(text, enc);
    }
    
    public static string SHA384Of(string text)
    {
    	return SHA384Of(text, Encoding.Default);
    }
    public static string SHA384Of(string text, Encoding enc)
    {
    	return HashOf<SHA384CryptoServiceProvider>(text, enc);
    }
    
    public static string SHA512Of(string text)
    {
    	return SHA512Of(text, Encoding.Default);
    }
    public static string SHA512Of(string text, Encoding enc)
    {
    	return HashOf<SHA512CryptoServiceProvider>(text, enc);
    }
    
    public static string SHA256Of(string text)
    {
    	return SHA256Of(text, Encoding.Default);
    }
    public static string SHA256Of(string text, Encoding enc)
    {
    	return HashOf<SHA256CryptoServiceProvider>(text, enc);
    }
    
    public static string HashOf<TP>(string text, Encoding enc)
    	where TP: HashAlgorithm, new()
    {
    	var buffer = enc.GetBytes(text);
    	var provider = new TP();
    	return BitConverter.ToString(provider.ComputeHash(buffer)).Replace("-", "");
    }
