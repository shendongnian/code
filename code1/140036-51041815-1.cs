    //Because of the random salt added, each time you hash a password it will create a new result.
		public static string GetHashedValue(string password)
		{
			//this will create a new hash?
			//Hashed Password Formula: Base64(salt + Sha1(salt + value))
			var crypto = new SHA1CryptoServiceProvider();
			byte[] saltBytes = new byte[16];
			RandomNumberGenerator.Create().GetBytes(saltBytes); 
			byte[] checkPasswordBytes = Encoding.Unicode.GetBytes(password);
			byte[] tempResult = crypto.ComputeHash(saltBytes.Concat(checkPasswordBytes).ToArray()); //ComputeHash(salt + value)
			byte[] resultBytes = saltBytes.Concat(tempResult).ToArray();  //salt + ComputeHash(salt + value)
			return Convert.ToBase64String(resultBytes);
		}
