		public static string Serial(string type, int length)
		{
			if (length < 1) return "";
			string chars;
			switch (type)
			{
				case "HEX":
					chars = "0123456789ABCDEF"; // 16
					break;
				case "hex":
					chars = "0123456789abcdef"; // 16
					break;
				case "DEC":
				case "dec":
				case "NUM":
				case "num":
					chars = "0123456789"; // 10
					break;
				case "ALPHA":
					chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // 26
					break;
				case "alpha":
					chars = "abcdefghijklmnopqrstuvwxyz"; // 26
					break;
				case "ALPHANUM":
					chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // 36
					break;
				case "alphanum":
					chars = "abcdefghijklmnopqrstuvwxyz0123456789"; // 36
					break;
				case "FULL":
				case "full":
				default:
					chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // 62
					break;
			}
			int limit = (256 / chars.Length) * chars.Length;
			StringBuilder result = new StringBuilder(length);
			foreach (byte b in SecureBytesInRange(limit,length))
			{
				result.Append(chars[b % chars.Length]);
			}
			return result.ToString();
		}
		private const int SECURE_BYTE_BUFFER_SIZE = 32;
		static IEnumerable<byte> SecureBytesInRange(int exclusiveUpperBound, int countRequired)
		{
			using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
			{
				byte[] buffer = new byte[SECURE_BYTE_BUFFER_SIZE];
				int ix = SECURE_BYTE_BUFFER_SIZE;
				int countProduced = 0;
				while (countProduced < countRequired)
				{
					if (ix == SECURE_BYTE_BUFFER_SIZE)
					{
						crypto.GetBytes(buffer);
						ix = 0;
					}
					while (ix < SECURE_BYTE_BUFFER_SIZE)
					{
						if (buffer[ix] < exclusiveUpperBound)
						{
							yield return buffer[ix];
							countProduced++;
							if (countProduced == countRequired) break;
						}
						ix++;
					}
				}
			}
		}
