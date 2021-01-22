    string RandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789") {
    	if (length < 0) throw new ArgumentOutOfRangeException("length must be >= 0.");
    	if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");
    
    	// Guid.NewGuid and System.Random are not particularly random. By using a
    	// cryptographically secure random number generator, the caller is always
    	// protected, regardless of use.
    	using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider()) {
    		var result = new StringBuilder();
    		var buf = new byte[128];
    		while (result.Length < length) {
    			rng.GetBytes(buf);
    			for (var i = 0; i < buf.Length && result.Length < length; ++i) {
    				var c = (char) buf[i];
    				// Ignore values outside of the allowed range, in order to
    				// avoid biasing the result.
    				if (allowedChars.IndexOf(c) < 0) continue;
    				result.Append(c);
    			}
    		}
    		return result.ToString();
    	}
    }
