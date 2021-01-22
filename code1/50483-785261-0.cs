    HashAlgorithm hash = new SHA256Managed();
    string password = "12345";
    string salt = "UserName";
    
    // compute hash of the password
    byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
    byte[] hashBytes = hash.ComputeHash(plainTextBytes);
    
    // create salted byte array
    byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
    byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];
    for (int i = 0; i < plainTextBytes.Length; i++)
    {
       plainTextWithSaltBytes[i] = plainTextBytes[i];
    }
    
    // compute salted hash
    byte[] saltedHashBytes = hash.ComputeHash(plainTextWithSaltBytes);
    string saltedHashValue = Convert.ToBase64String(saltedHashBytes);
