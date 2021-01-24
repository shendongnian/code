	public static void Main()
	{
		var hex = "7B5C727466315C616465666C616E67313032355C616E73695C";
		var rtfBytes = FromHex(hex);
		var rtfText = Encoding.ASCII.GetString(rtfBytes);
		Console.WriteLine(rtfText);
	}
	
	public static byte[] FromHex(string hex)
	{
	    var result = new byte[hex.Length / 2];
	    for (var i = 0; i < result.Length; i++)
	    {
	        result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
	    }
	    return result;
	}
