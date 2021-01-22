    static ConcurrentStack<ICryptoTransform> decryptors = new ConcurrentStack<ICryptoTransform>();
    void Encrypt()
    {
       // Pop decryptor from cache...
       ICryptoTransform decryptor;
       if (!decryptors.TryPop(out decryptor))
       {
           // ... or create a new one since cache is depleted
           AesManaged aes = new AesManaged();
           aes.Key = key;
           aes.IV = iv;
           decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        }
        try
        {
           //// use decryptor
        }
        finally
        {
           decryptors.Push(decryptor);
        }
     }
