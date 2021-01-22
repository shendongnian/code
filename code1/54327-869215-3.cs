    private static Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters recreateASymCipherPublicKey(CipherPublicKey cPublicKey)
    {
        //keyPair.Public	{Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters}	Org.BouncyCastle.Crypto.AsymmetricKeyParameter {Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters}
        Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters key;
        //RsaKeyParameters.RsaKeyParameters( 
        //    bool isPrivate, 
        //    Org.BouncyCastle.Math.BigInteger modulus, 
        //    Org.BouncyCastle.Math.BigInteger exponent )
        key = new Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters(
                cPublicKey.isPrivate,
                createBigInteger(cPublicKey.modulus),
                createBigInteger(cPublicKey.exponent));
        return key;
    }
    
    private static Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters recreateASymCipherPrivateKey(CipherPrivateKey cPrivateKey)
    {
        //keyPair.Private	{Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters}	Org.BouncyCastle.Crypto.AsymmetricKeyParameter {Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters}
        Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters key;
        //RsaPrivateCrtKeyParameters.RsaPrivateCrtKeyParameters( 
        //    Org.BouncyCastle.Math.BigInteger modulus, 
        //    Org.BouncyCastle.Math.BigInteger publicExponent, 
        //    Org.BouncyCastle.Math.BigInteger privateExponent, 
        //    Org.BouncyCastle.Math.BigInteger p, 
        //    Org.BouncyCastle.Math.BigInteger q, 
        //    Org.BouncyCastle.Math.BigInteger dP, 
        //    Org.BouncyCastle.Math.BigInteger dQ, 
        //    Org.BouncyCastle.Math.BigInteger qInv )
        key = new Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters(
                createBigInteger(cPrivateKey.modulus),
                createBigInteger(cPrivateKey.publicExponent),
                createBigInteger(cPrivateKey.privateExponent),
                createBigInteger(cPrivateKey.p),
                createBigInteger(cPrivateKey.q),
                createBigInteger(cPrivateKey.dP),
                createBigInteger(cPrivateKey.dQ),
                createBigInteger(cPrivateKey.qInv));
        return key;
    }
