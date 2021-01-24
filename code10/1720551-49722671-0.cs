    void Main()
    {
    	var cipher = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";
    	var charArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789!£$%^&*()_+";
    	var decoded = FromHex(cipher);
    	foreach(var c in charArray)
    	{
    		Console.WriteLine("{0}: {1}", c.ToString(), new string(decoded.Select(x => x^c).Select(x => (char)x).ToArray()));
    	}
    }
    
    public static byte[] FromHex(string hex)
    {
    	hex = hex.Replace("-", "");
    	byte[] raw = new byte[hex.Length / 2];
    	for (int i = 0; i < raw.Length; i++)
    	{
    		raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
    	}
    	return raw;
    }
