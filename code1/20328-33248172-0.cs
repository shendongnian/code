		/// <summary>
		/// Converts the byte array to a hex string very fast. Excellent job
		/// with code lightly adapted from 'community wiki' here: http://stackoverflow.com/a/14333437/264031
		/// (the function was originally named: ByteToHexBitFiddle). Now allows a native lowerCase option
		/// to be input and allows null or empty inputs (null returns null, empty returns empty).
		/// </summary>
		public static string ToHexString(this byte[] bytes, bool lowerCase = false)
		{
			if (bytes == null)
				return null;
			else if (bytes.Length == 0)
				return "";
			char[] c = new char[bytes.Length * 2];
			int b;
			int xAddToAlpha = lowerCase ? 87 : 55;
			int xAddToDigit = lowerCase ? -39 : -7;
			for (int i = 0; i < bytes.Length; i++) {
				b = bytes[i] >> 4;
				c[i * 2] = (char)(xAddToAlpha + b + (((b - 10) >> 31) & xAddToDigit));
				b = bytes[i] & 0xF;
				c[i * 2 + 1] = (char)(xAddToAlpha + b + (((b - 10) >> 31) & xAddToDigit));
			}
			string val = new string(c);
			return val;
		}
		public static string ToHexString(this IEnumerable<byte> bytes, bool lowerCase = false)
		{
			if (bytes == null)
				return null;
			byte[] arr = bytes.ToArray();
			return arr.ToHexString(lowerCase);
		}
