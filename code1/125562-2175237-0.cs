    public static void Main(string[] args)
    {
    	using (HashAlgorithm hashAlg = new SHA1Managed())
    	{
    		using (Stream file = new FileStream("C:\\test.txt", FileMode.Open, FileAccess.Read))
    		{
    			byte[] hash = hashAlg.ComputeHash(file);
    			Console.WriteLine(BitConverter.ToString(hash));
    		}
    	}
    }
