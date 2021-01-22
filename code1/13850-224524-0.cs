    class Program
    {
    	static void Main(string[] args)
    	{
    		Console.WriteLine(Decrypt("47794945c0230c3d"));
    	}
    
    	static string Decrypt(string input)
    	{
    		TripleDES tripleDes = TripleDES.Create();
    		tripleDes.IV = Encoding.ASCII.GetBytes("password");
    		tripleDes.Key = Encoding.ASCII.GetBytes("passwordDR0wSS@P6660juht");
    		tripleDes.Mode = CipherMode.CBC;
    		tripleDes.Padding = PaddingMode.Zeros;
    
    		ICryptoTransform crypto = tripleDes.CreateDecryptor();
    		byte[] decodedInput = Decoder(input);
    		byte[] decryptedBytes = crypto.TransformFinalBlock(decodedInput, 0, decodedInput.Length);
    		return Encoding.ASCII.GetString(decryptedBytes);
    	}
    
    	static byte[] Decoder(string input)
    	{
    		byte[] bytes = new byte[input.Length/2];
    		int targetPosition = 0;
    
    		for( int sourcePosition=0; sourcePosition<input.Length; sourcePosition+=2 )
    		{
    			string hexCode = input.Substring(sourcePosition, 2);
    			bytes[targetPosition++] = Byte.Parse(hexCode, NumberStyles.AllowHexSpecifier);
    		}
    
    		return bytes;
    	}
    }
