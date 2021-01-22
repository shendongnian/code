     CspParameters parms = new CspParameters();
     parms.KeyNumber = 2;
     
     RSACryptoServiceProvider provider = new RSACryptoServiceProvider(parms);
     byte[] array = provider.ExportCspBlob(!provider.PublicOnly);
     StrongNameKeyPair snk = new StrongNameKeyPair(array);
     byte[] publicKey = snk.PublicKey;
