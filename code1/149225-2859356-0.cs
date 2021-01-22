    private static void EncryptFile(
            Stream	outputStream,
            string	fileName,
            char[]	passPhrase,
            bool	armor,
            bool	withIntegrityCheck)
        {
            if (armor)
            {
                outputStream = new ArmoredOutputStream(outputStream);
            }
			MemoryStream bOut = new MemoryStream();
			PgpCompressedDataGenerator comData = new PgpCompressedDataGenerator(
				CompressionAlgorithmTag.Zip);
			PgpUtilities.WriteFileToLiteralData(
				comData.Open(bOut),
				PgpLiteralData.Binary,
				new FileInfo(fileName));
			comData.Close();
			byte[] bytes = bOut.ToArray();
			PgpEncryptedDataGenerator cPk = new PgpEncryptedDataGenerator(
				SymmetricKeyAlgorithmTag.Cast5, withIntegrityCheck, new SecureRandom());
			cPk.AddMethod(passPhrase);
			Stream cOut = cPk.Open(outputStream, bytes.Length);
            cOut.Write(bytes, 0, bytes.Length);
			cOut.Close();
			if (armor)
			{
				outputStream.Close();
			}
        }
