    public static void Main()
	{
		string hexString = "0030003100320033"; //Hexa pair numeric values
		//string hexStrWithDash = "00-30-00-31-00-32-00-33"; //Hexa pair numeric values separated by dashed. This occurs using BitConverter.ToString()
		byte[] data = ParseHex(hexString);
		string result = System.Text.Encoding.BigEndianUnicode.GetString(data); 
		Console.Write("Data: {0}", result);
	}
	public static byte[] ParseHex(string hexString)
	{
		hexString = hexString.Replace("-", "");
		byte[] output = new byte[hexString.Length / 2];
		for (int i = 0; i < output.Length; i++)
		{
			output[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
		}
		return output;
	}
