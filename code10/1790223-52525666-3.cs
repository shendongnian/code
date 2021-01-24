    public byte[] GenerateKeyMcryptSha1(string passPhrase, byte[] salt, int keySize)
    {
        byte[] key = new byte[KeySize], digest = null;
        int hashSize = 20;
        byte[] password = Encoding.ASCII.GetBytes(passPhrase);
        int keyBytes = 0;
    
        while (true)
        {
            byte[] inputData = null;
            using (MemoryStream stream = new MemoryStream())
            {
                if (Salt != null)
                    stream.Write(salt, 0, salt.Length);
                stream.Write(password, 0, password.Length);
                if (keyBytes > 0)
                    stream.Write(key, 0, keyBytes);
                inputData = stream.ToArray();
            }
    
            using (var sha1 = new SHA1Managed())
                digest = sha1.ComputeHash(inputData);
    
            if (keySize > hashSize)
            {
                Buffer.BlockCopy(digest, 0, key, keyBytes, hashSize);
                keySize -= hashSize;
                keyBytes += hashSize;
            }
            else
            {
                Buffer.BlockCopy(digest, 0, key, keyBytes, keySize);
                break;
            }                
        }
    
        return key;
    }
            
         
