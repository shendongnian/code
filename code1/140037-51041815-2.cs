    public static bool IsPasswordValid(string passwordToCheck, string savedPassword)
		{
			bool retVal = false;
			var crypto = new SHA1CryptoServiceProvider();
			//get the salt, which is part of the saved password. These are the first 16 bytes.
			byte[] storedPasswordBytes = Convert.FromBase64String(savedPassword);
			byte[] saltBytes = new byte[16];
			Array.Copy(storedPasswordBytes, saltBytes, 16);
			//hash the password that you want to check with the same salt and the same algoritm:
			byte[] checkPasswordBytes = Encoding.Unicode.GetBytes(passwordToCheck);
			byte[] tempResult = crypto.ComputeHash(saltBytes.Concat(checkPasswordBytes).ToArray()); //ComputeHash(salt + value)
			byte[] resultBytes = saltBytes.Concat(tempResult).ToArray();  //salt + ComputeHash(salt + value)
			string resultString = Convert.ToBase64String(resultBytes);
			if (savedPassword == resultString)
			{
				retVal = true;
			}
			return retVal;
		}
