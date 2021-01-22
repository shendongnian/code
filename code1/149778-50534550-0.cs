    using System;
    using System.Security.Cryptography;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var random = new Random(GetSeed());
    		Console.WriteLine(random.Next());
    	}
    	
    	public static int GetSeed() 
        {
    		using (var rng = new RNGCryptoServiceProvider())
    		{
    			var intBytes = new byte[4];
    			rng.GetBytes(intBytes);
    			return BitConverter.ToInt32(intBytes, 0);
    		}
    	}
    }
