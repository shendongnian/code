    byte[] a = new byte[32];
    RandomNumberGenerator gen = new RNGCryptoServiceProvider();
    gen.GetBytes(a);
    UnicodeEncoding byteConverter = new UnicodeEncoding();
    byte[] b = byteConverter.GetBytes(byteConverter.GetString(a));
    //byte array 'a' and byte array 'b' will not always contain the same elements.
