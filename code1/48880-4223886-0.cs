    var keygen = new RsaKeyPairGenerator();
    keygen.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
    
    var keys = keygen.GenerateKeyPair();
    
    var certGen = new X509V3CertificateGenerator();
    var dnName = new X509Name("CN=Test CA");
    
    certGen.SetSerialNumber(BigInteger.ValueOf(1));
    certGen.SetIssuerDN(dnName);
    certGen.SetNotBefore(DateTime.Today);
    certGen.SetNotAfter(DateTime.Today.AddYears(10));
    certGen.SetSubjectDN(dnName);
    certGen.SetPublicKey(keys.Public);
    certGen.SetSignatureAlgorithm("SHA1WITHRSA");
    
    var cert = certGen.Generate(keys.Private);
