    using System;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    
    class Program
    {
    	static async Task Main(string[] args)
    	{
    		var b = new byte[4096];
    		var c = Encrypt(b);
    		Console.ReadLine();
    	}
    
    	private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
    	private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
    
    	private static byte[] Encrypt(byte[] inputBuffer)
    	{
    		SymmetricAlgorithm algorithm = DES.Create();
    		ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
    		byte[] outputBuffer = transform.TransformFinalBlock(
                                    inputBuffer,
                                    0,
                                    inputBuffer.Length);
    		return outputBuffer;
    	}
    }
