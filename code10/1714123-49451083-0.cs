    public class EncryptionHelper
	{
		#region Private Fields
		// This constant determines the number of iterations for the password bytes generation function.
		private const int DerivationIterations = 1000;
		// This constant is used to determine the keysize of the encryption algorithm in bits.
		// We divide this by 8 within the code below to get the equivalent number of bytes.
		private const int saltBytes = 32; //  bytes
		private const int ivBytes = 16; // bytes
		#endregion Private Fields
		#region Public Methods
		/// <summary>Decrypts the specified cipher text.</summary>
		/// <param name="cipherText">The cipher text.</param>
		/// <param name="passPhrase">The pass phrase.</param>
		/// <returns></returns>
		public static string Decrypt(string cipherText, string passPhrase)
		{
			// Get the complete stream of bytes that represent:
			// [32 bytes of Salt] + [16 bytes of IV] + [n bytes of CipherText]
			byte[] cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);	
			// Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
			byte[] saltStringBytes = cipherTextBytesWithSaltAndIv.Take(saltBytes).ToArray();
			// Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
			byte[] ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(saltBytes).Take(ivBytes).ToArray();
			// Get the actual cipher text bytes by removing the first 48 bytes from the cipherText string.
			byte[] cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip(saltBytes + ivBytes).Take(cipherTextBytesWithSaltAndIv.Length - (saltBytes + ivBytes)).ToArray();
			using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
			{
				byte[] keyBytes = password.GetBytes(saltBytes);
				using (var symmetricKey = new AesCryptoServiceProvider())
				{
					symmetricKey.BlockSize = 128;
					symmetricKey.Mode = CipherMode.CBC;
					symmetricKey.Padding = PaddingMode.PKCS7;
					using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
					using (var memoryStream = new MemoryStream(cipherTextBytes))
					using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
					{
						var plainTextBytes = new byte[cipherTextBytes.Length];
						int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
						memoryStream.Close();
						cryptoStream.Close();
						return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
					}
				}
			}
		}
		/// <summary>Encrypts the specified plain text.</summary>
		/// <param name="plainText">The plain text.</param>
		/// <param name="passPhrase">The pass phrase.</param>
		/// <returns></returns>
		public static string Encrypt(string plainText, string passPhrase)
		{
			// Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
			// so that the same Salt and IV values can be used when decrypting.  
			byte[] saltStringBytes = GenerateBitsOfRandomEntropy(32);
			byte[] ivStringBytes = GenerateBitsOfRandomEntropy(16);
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
			{
				byte[] keyBytes = password.GetBytes(saltBytes);
				using (var symmetricKey = new AesCryptoServiceProvider())
				{
					symmetricKey.BlockSize = 128;
					symmetricKey.Mode = CipherMode.CBC;
					symmetricKey.Padding = PaddingMode.PKCS7;
					using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
					{
						using (var memoryStream = new MemoryStream())
						{
							using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
							{
								cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
								cryptoStream.FlushFinalBlock();
								// Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
								byte[] cipherTextBytes = saltStringBytes;
								cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
								cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
								memoryStream.Close();
								cryptoStream.Close();
								return Convert.ToBase64String(cipherTextBytes);
							}
						}
					}
				}
			}
		}
		#endregion Public Methods
		#region Private Methods
		/// <summary>Generate bits of random entropy.</summary>
		/// <returns></returns>
		private static byte[] GenerateBitsOfRandomEntropy(int num)
		{
			var randomBytes = new byte[num]; // 32 Bytes will give us 256 bits.
			using (var rngCsp = new RNGCryptoServiceProvider())
			{
				// Fill the array with cryptographically secure random bytes.
				rngCsp.GetBytes(randomBytes);
			}
			return randomBytes;
		}
		#endregion Private Methods
