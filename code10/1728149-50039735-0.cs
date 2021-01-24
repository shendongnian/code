    public static string ConvertToHash(string dataToComputeHash)
		{
			var hash = "";
			try
			{
				var keyByte = encoding.GetBytes(key);
				using (var hmacsha256 = new HMACSHA256(keyByte))
				{
					hmacsha256.ComputeHash(encoding.GetBytes(dataToComputeHash));
					hash = ByteToString(hmacsha256.Hash);
				}
			}
			catch (Exception ex)
			{
			
			}
			return hash;
		}
