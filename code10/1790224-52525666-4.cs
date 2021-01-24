    /// <summary>
    /// Decrypt using Rijndael
    /// </summary>
    /// <param name="key">Key to use for decryption that was generated from passphrase + salt</param>
    /// <param name="keySize">Algo key size, e.g. 128 bit, 256 bit</param>
    /// <returns>Unencrypted data</returns>
    private byte[] DecryptRijndael(byte[] key, int keySize)
    {
        using (RijndaelManaged rijndael = GetRijndael(key, keySize))
        {
            rijndael.IV = InitialisationVector;
            using (MemoryStream unencryptedStream = new MemoryStream())
            using (MemoryStream encryptedStream = new MemoryStream(EncryptedData))
            {
                using (var cs = new CryptoStream(encryptedStream, rijndael.CreateDecryptor(), CryptoStreamMode.Read))
                    cs.CopyTo(unencryptedStream);
                    
                byte[] unencryptedData = RemovePaddingAndCheckSum(unencryptedStream.ToArray(), GetCheckSumLen());                    
                return unencryptedData;
            }
        }
    }
    /// <summary>
    /// Set algorithm mode/settings
    /// </summary>
    /// <param name="key">Key to use for decryption that was generated from passphrase + salt</param>
    /// <param name="keySize">Algo key size, e.g. 128 bit, 256 bit</param>
    /// <returns>Instance ready to decrypt</returns>
    private RijndaelManaged GetRijndael(byte[] key, int keySize)
    {
        var rijndael = new RijndaelManaged()
        {
            Mode = CipherMode, // e.g. CBC
            KeySize = keySize, // e.g. 256 bits
            Key = key, // e.g. 32-byte sha-1 hash of passphrase + salt
            BlockSize = BlockSize, // e.g. 256 bits
            Padding = PaddingMode.Zeros
        };
        return rijndael;
    }
