     var pkcs8PublicKey = new DerSequence(
         new DerSequence(
             new DerObjectIdentifier("1.2.840.113549.1.1.1"),
             DerNull.Instance),
         new DerBitString(publicKeyFromKeyChain)
     ).GetDerEncoded();
