        public static byte[] Encrypt(byte[] input, AsymmetricCipherKeyPair keyPair)
        {
            CmsEnvelopedDataGenerator generator = new CmsEnvelopedDataGenerator();
            DerObjectIdentifier	algOid = //initialize
            //Still trying to figure out kekId here.
            byte[] kekId = new byte[] { 1, 2, 3, 4, 5 };
            string keyAlgorithm = ParameterUtilities.GetCanonicalAlgorithmName("AES256");
            generator.AddKekRecipient(keyAlgorithm, keyPair.Public, kekId);
            CmsProcessableByteArray cmsByteArray = new CmsProcessableByteArray(input);
            CmsEnvelopedData envelopeData =
              generator.Generate(cmsByteArray, CmsEnvelopedDataGenerator.Aes256Cbc);
            return envelopeData.GetEncoded();
        }
