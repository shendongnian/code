    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    des.GenerateKey();
    byte[] key = des.Key; // save this!
    
    ICryptoTransform encryptor = des.CreateEncryptor();
    // encrypt
    byte[] enc = encryptor.TransformFinalBlock(new byte[] { 1, 2, 3, 4 }, 0, 4);
    
    ICryptoTransform decryptor = des.CreateDecryptor();
    
    // decrypt
    byte[] originalAgain = decryptor.TransformFinalBlock(enc, 0, enc.Length);
    Debug.Assert(originalAgain[0] == 1);
