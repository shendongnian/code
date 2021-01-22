    internal static string GetHashCode(string filePath, HashAlgorithm cryptoService)
    {
    // create or use the instance of the crypto service provider
    // this can be either MD5, SHA1, SHA256, SHA384 or SHA512
    using (cryptoService)
    {
        using (var fileStream = new FileStream(filePath, 
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.ReadWrite))
        {
            var hash = cryptoService.ComputeHash(fileStream);
            var hashString = Convert.ToBase64String(hash);
            return hashString.TrimEnd('=');
         }
      }
    }
      WriteLine("MD5 Hash Code   : {0}", GetHashCode(FilePath, new MD5CryptoServiceProvider()));
      WriteLine("SHA1 Hash Code  : {0}", GetHashCode(FilePath, new SHA1CryptoServiceProvider()));
      WriteLine("SHA256 Hash Code: {0}", GetHashCode(FilePath, new SHA256CryptoServiceProvider()));
      WriteLine("SHA384 Hash Code: {0}", GetHashCode(FilePath, new SHA384CryptoServiceProvider()));
      WriteLine("SHA512 Hash Code: {0}", GetHashCode(FilePath, new SHA512CryptoServiceProvider()));
