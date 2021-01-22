    public static class CryptographyProvider
        {
            public static string EncryptString(string plainText, out string Key)
            {
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
    
                using (Aes _aesAlg = Aes.Create())
                {
                    Key = Convert.ToBase64String(_aesAlg.Key);
                    ICryptoTransform _encryptor = _aesAlg.CreateEncryptor(_aesAlg.Key, _aesAlg.IV);
    
                    using (MemoryStream _memoryStream = new MemoryStream())
                    {
                        _memoryStream.Write(_aesAlg.IV, 0, 16);
                        using (CryptoStream _cryptoStream = new CryptoStream(_memoryStream, _encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter _streamWriter = new StreamWriter(_cryptoStream))
                            {
                                _streamWriter.Write(plainText);
                            }
                            return Convert.ToBase64String(_memoryStream.ToArray());
                        }
                    }
                }
            }
            public static string DecryptString(string cipherText, string Key)
            {
    
                if (string.IsNullOrEmpty(cipherText))
                    throw new ArgumentNullException("cipherText");
                if (string.IsNullOrEmpty(Key))
                    throw new ArgumentNullException("Key");
    
                string plaintext = null;
    
                byte[] _initialVector = new byte[16];
                byte[] _Key = Convert.FromBase64String(Key);
                byte[] _cipherTextBytesArray = Convert.FromBase64String(cipherText);
                byte[] _originalString = new byte[_cipherTextBytesArray.Length - 16];
    
                Array.Copy(_cipherTextBytesArray, 0, _initialVector, 0, _initialVector.Length);
                Array.Copy(_cipherTextBytesArray, 16, _originalString, 0, _cipherTextBytesArray.Length - 16);
    
                using (Aes _aesAlg = Aes.Create())
                {
                    _aesAlg.Key = _Key;
                    _aesAlg.IV = _initialVector;
                    ICryptoTransform decryptor = _aesAlg.CreateDecryptor(_aesAlg.Key, _aesAlg.IV);
    
                    using (MemoryStream _memoryStream = new MemoryStream(_originalString))
                    {
                        using (CryptoStream _cryptoStream = new CryptoStream(_memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader _streamReader = new StreamReader(_cryptoStream))
                            {
                                plaintext = _streamReader.ReadToEnd();
                            }
                        }
                    }
                }
                return plaintext;
            }
        }
