	public static void EncryptPgpFile(string inputFile, string outputFile, string publicKeyFile, bool armor, bool withIntegrityCheck)
	{
		using (Stream publicKeyStream = File.OpenRead(publicKeyFile))
		{
			PgpPublicKey pubKey = ReadPublicKey(publicKeyStream);
			using (MemoryStream outputBytes = new MemoryStream())
			{
				PgpCompressedDataGenerator dataCompressor = new PgpCompressedDataGenerator(CompressionAlgorithmTag.Zip);
				PgpUtilities.WriteFileToLiteralData(dataCompressor.Open(outputBytes), PgpLiteralData.Binary, new FileInfo(inputFile));
				dataCompressor.Close();
				PgpEncryptedDataGenerator dataGenerator = new PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag.Cast5, withIntegrityCheck, new SecureRandom());
				dataGenerator.AddMethod(pubKey);
				byte[] dataBytes = outputBytes.ToArray();
				using (Stream outputStream = File.Create(outputFile))
				{
					if (armor)
					{
						using (ArmoredOutputStream armoredStream = new ArmoredOutputStream(outputStream))					
						using (Stream outputStream = dataGenerator.Open(armoredStream, dataBytes.Length))
							outputStream.Write(dataBytes, 0, dataBytes.Length);
					}
					else
					{
						using (Stream outputStream = dataGenerator.Open(armoredStream, dataBytes.Length))
							outputStream.Write(dataBytes, 0, dataBytes.Length);
					}
				}
			}
		}
	}
	
	private static PgpPublicKey ReadPublicKey(Stream inputStream)
	{
		inputStream = PgpUtilities.GetDecoderStream(inputStream);
		PgpPublicKeyRingBundle pgpPub = new PgpPublicKeyRingBundle(inputStream);
		foreach (PgpPublicKeyRing keyRing in pgpPub.GetKeyRings())
		{
			foreach (PgpPublicKey key in keyRing.GetPublicKeys())
			{
				if (key.IsEncryptionKey)
					return key;
			}
		}
		throw new ArgumentException("Can't find encryption key in key ring.");
	}
