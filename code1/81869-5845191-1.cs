    using (var rsa = new RSACryptServiceProvider(1024))
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
