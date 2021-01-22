            /// <summary>
    		/// Convert an integer to a string of hexidecimal numbers.
    		/// </summary>
    		/// <param name="n">The int to convert to Hex representation</param>
    		/// <param name="len">number of digits in the hex string. Pads with leading zeros.</param>
    		/// <returns></returns>
    		private static String IntToHexString(int n, int len)
    		{
    			char[] ch = new char[len--];
    			for (int i = len; i >= 0; i--)
    			{
    				ch[len - i] = ByteToHexChar((byte)((uint)(n >> 4 * i) & 15));
    			}
    			return new String(ch);
    		}
    
    		/// <summary>
    		/// Convert a byte to a hexidecimal char
    		/// </summary>
    		/// <param name="b"></param>
    		/// <returns></returns>
    		private static char ByteToHexChar(byte b)
    		{
    			if (b < 0 || b > 15)
    				throw new Exception("IntToHexChar: input out of range for Hex value");
    			return b < 10 ? (char)(b + 48) : (char)(b + 55);
    		}
    
    		/// <summary>
    		/// Convert a hexidecimal string to an base 10 integer
    		/// </summary>
    		/// <param name="str"></param>
    		/// <returns></returns>
    		private static int HexStringToInt(String str)
    		{
    			int value = 0;
    			for (int i = 0; i < str.Length; i++)
    			{
    				value += HexCharToInt(str[i]) << ((str.Length - 1 - i) * 4);
    			}
    			return value;
    		}
    
    		/// <summary>
    		/// Convert a hex char to it an integer.
    		/// </summary>
    		/// <param name="ch"></param>
    		/// <returns></returns>
    		private static int HexCharToInt(char ch)
    		{
    			if (ch < 48 || (ch > 57 && ch < 65) || ch > 70)
    				throw new Exception("HexCharToInt: input out of range for Hex value");
    			return (ch < 58) ? ch - 48 : ch - 55;
    		}
