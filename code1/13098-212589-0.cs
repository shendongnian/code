    // Convert the plain string pwd into bytes
    byte[] plainTextBytes = System.Text UnicodeEncoding.Unicode.GetBytes(plainText);
    // Append salt to pwd before hashing
    byte[] combinedBytes = new byte[plainTextBytes.Length + salt.Length];
    System.Buffer.BlockCopy(plainTextBytes, 0, combinedBytes, 0, plainTextBytes.Length);
    System.Buffer.BlockCopy(salt, 0, combinedBytes, plainTextBytes.Length, salt.Length);
