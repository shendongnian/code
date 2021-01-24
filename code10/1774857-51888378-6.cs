    string encryptedstring = EncryptionExtension.CryptString(
            EncryptionExtension.CryptMethod.Encrypt, EncryptionExtension.EncryptionAlgorithms.Rijndael, 
                "Some text to encrypt, more text to encrypt", "SomeKey");
    string decryptedstring = EncryptionExtension.CryptString(
            EncryptionExtension.CryptMethod.Decrypt, EncryptionExtension.EncryptionAlgorithms.Rijndael, 
                encryptedstring, "SomeKey");
---
    #region "String Encryption"
    public static string EncryptString(EncryptionAlgorithms Method, string Value, string Key)
    {
        return CryptString(CryptMethod.Encrypt, Method, Value, Key);
    }
    public static string DecryptString(EncryptionAlgorithms Method, string Value, string Key)
    {
        return CryptString(CryptMethod.Decrypt, Method, Value, Key);
    }
