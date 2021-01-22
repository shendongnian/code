    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var key = Encoding.UTF8.GetBytes("SUkbqO2ycDo7QwpR25kfgmC7f8CoyrZy");
    		var data = Encoding.UTF8.GetBytes("testData");
    		
    		//Encrypt data
    		var encrypted = CryptoHelper.EncryptData(data,key);
    		
    		//Decrypt data
    		var decrypted = CryptoHelper.DecryptData(encrypted,key);
    		
    		//Display result
    		Console.WriteLine(Encoding.UTF8.GetString(decrypted));
    	}
    }
    
    public static class CryptoHelper
    {
    	public static byte[] EncryptData(byte[] data, byte[] key)
    	{
    		using (var aesAlg = Aes.Create())
    		{
    			aesAlg.Mode = CipherMode.CBC;
    			using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
    			{
    				using (var msEncrypt = new MemoryStream())
    				{
    					msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
    
    					using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
    						csEncrypt.Write(data, 0, data.Length);
    
    					return msEncrypt.ToArray();
    				}
    			}
    		}
    
    	}
    
    	public static byte[] DecryptData(byte[] encrypted, byte[] key)
    	{
    		var iv = new byte[16];
    		Buffer.BlockCopy(encrypted, 0, iv, 0, iv.Length);
    		using (var aesAlg = Aes.Create())
    		{
    			aesAlg.Mode = CipherMode.CBC;
    			using (var decryptor = aesAlg.CreateDecryptor(key, iv))
    			{
    				using (var msDecrypt = new MemoryStream(encrypted, iv.Length, encrypted.Length - iv.Length))
    				{
    					using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
    					{
    						using (var resultStream = new MemoryStream())
    						{
    							csDecrypt.CopyTo(resultStream);
    							return resultStream.ToArray();
    						}
    					}
    				}
    			}
    		}
    	}
    }
