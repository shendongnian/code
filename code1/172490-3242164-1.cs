	public static AsymmetricKeyParameter TransformRSAPrivateKey(AsymmetricAlgorithm privateKey)
	{
		RSACryptoServiceProvider prov = privateKey as RSACryptoServiceProvider;
		RSAParameters parameters = prov.ExportParameters(true);
		
		return new RsaPrivateCrtKeyParameters(
			new BigInteger(1,parameters.Modulus),
			new BigInteger(1,parameters.Exponent),
			new BigInteger(1,parameters.D),
			new BigInteger(1,parameters.P),
			new BigInteger(1,parameters.Q),
			new BigInteger(1,parameters.DP),
			new BigInteger(1,parameters.DQ),
			new BigInteger(1,parameters.InverseQ));
	}
