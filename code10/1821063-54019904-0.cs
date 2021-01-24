        public static void GetRsaKeyPair(out string privateXml, out string publicXml)
        {
            CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
            SecureRandom secureRandom = new SecureRandom(randomGenerator);
            var keyGenerationParameters = new KeyGenerationParameters(secureRandom, 1024);
            var rsaKeyPairGenerator = new RsaKeyPairGenerator();
            rsaKeyPairGenerator.Init(keyGenerationParameters);
            AsymmetricCipherKeyPair rsaKeyPair = rsaKeyPairGenerator.GenerateKeyPair();
            var privateRsaParameters = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)rsaKeyPair.Private);
            using (RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider())
            {
                rsaProvider.ImportParameters(privateRsaParameters);
                privateXml = rsaProvider.ToXmlString(true);
                publicXml = rsaProvider.ToXmlString(false);
            }
        }
