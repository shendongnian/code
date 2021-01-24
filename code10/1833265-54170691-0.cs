    var key = Encoding.UTF8.GetBytes("abcdefg");
    var hash = new HMACSHA256(key);
    var message = Encoding.UTF8.GetBytes("Hello, World!");
    byte[] signature = hash.ComputeHash(message);
		StringBuilder hexDigest = new StringBuilder();
		foreach (byte b in signature)
			 hexDigest.Append(String.Format("{0:x2}", b));
