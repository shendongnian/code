    private static string DecodeBinaryBase64(string stringToDecode)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var b in Convert.FromBase64String(stringToDecode))
            builder.Append(string.Format("{0:X2}", b));
        return "0x" + builder.ToString();
    }
    
    private static string EncodeBinaryBase64(string stringToEncode)
    {
    	var binary = new List<byte>();
    	for(int i = 2; i < stringToEncode.Length; i += 2)
    	{
            string s = new string(new [] {stringToEncode[i], stringToEncode[i+1]});
    		binary.Add(byte.Parse(s, NumberStyles.HexNumber));
    	}
    	return Convert.ToBase64String(binary.ToArray());
    }
