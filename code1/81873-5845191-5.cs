    using (var rsa = new RSACryptoServiceProvider(1024))
    {
       try
       {
          // Do something with the key...
          // Encrypt, export, etc.
       }
       finally
       {
          rsa.PersistKeyInCsp = false;
       }
    }
