    using PCLCrypto;
    using System;
    using System.Text;
    
    namespace SOcrypto
    {
    	class Program
    	{
    		static string Hex(byte[] bb)
    		{
    			StringBuilder sb = new StringBuilder();
    			for (int i = 0; i < bb.Length; i++)
    			{
    				sb.Append(bb[i].ToString("X2"));
    			}
    			return sb.ToString();
    		}
    
    		static void Main(string[] args)
    		{
    			var testData = Encoding.Unicode.GetBytes("Hello, World!");
    			var cryptoProvider = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
    			var hash_VA = cryptoProvider.HashData(testData);
    
    			Console.WriteLine("hash_VA.Length = " + hash_VA.Length);
    
    			var asHex = Hex(hash_VA);
    			var asB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(asHex));
    
    			Console.WriteLine("asB64.Length = " + asB64.Length);
    
    			Console.ReadLine();
    
    		}
    	}
    }
