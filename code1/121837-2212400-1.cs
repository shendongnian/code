	using System;
	using System.Text;
	using System.Security.Cryptography;
	namespace smsfwdClient
	{
		public class Crypto
		{
			private ICryptoTransform rijndaelDecryptor;
			// Replace me with a 16-byte key, share between Java and C#
			private static byte[] rawSecretKey = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			                                      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
			public Crypto(string passphrase)
			{
				byte[] passwordKey = encodeDigest(passphrase);
				RijndaelManaged rijndael = new RijndaelManaged();
				rijndaelDecryptor = rijndael.CreateDecryptor(passwordKey, rawSecretKey);
			}
			public string Decrypt(byte[] encryptedData)
			{
				byte[] newClearData = rijndaelDecryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
				return Encoding.ASCII.GetString(newClearData);
			}
			public string DecryptFromBase64(string encryptedBase64)
			{
				return Decrypt(Convert.FromBase64String(encryptedBase64));
			}
			private byte[] encodeDigest(string text)
			{
				MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] data = Encoding.ASCII.GetBytes(text);
				return x.ComputeHash(data);
			}
		}
	}
