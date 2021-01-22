    //DSA Key Pair Generator
    DsaKeyPairGenerator a = new DsaKeyPairGenerator();
            
    //DSA Key Parameter Generator
    DsaParametersGenerator paramgen = new DsaParametersGenerator();
    //Initialize Key Parameter Generator
    paramgen.Init(512, 100, new SecureRandom());
    
    //DSA KeyGeneration Parameters 
    DsaKeyGenerationParameters param = new DsaKeyGenerationParameters(new SecureRandom(), paramgen.GenerateParameters());
    //Initialize the Key Pair Generator
    a.Init(param);
    //The DSA Keys!
    AsymmetricCipherKeyPair keys = a.GenerateKeyPair();
    //PGP PubKey
    PgpPublicKey pub = new PgpPublicKey(Org.BouncyCastle.Bcpg.PublicKeyAlgorithmTag.Dsa, keys.Public, DateTime.Now);
    //PGP PrivKey
    PgpPrivateKey priv = new PgpPrivateKey(keys.Private, pub.KeyId);
