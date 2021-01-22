    public static void Decrypt( FileInfo sourceFile, string password )
    {
      // read salt
      var fileStream = sourceFile.OpenRead();
      var salt = new byte[SaltSize];
      fileStream.Read( salt, 0, SaltSize );
      // initialize algorithm with salt
      var keyGenerator = new Rfc2898DeriveBytes( password, salt );
      var rijndael = Rijndael.Create();
      rijndael.IV = keyGenerator.GetBytes( rijndael.BlockSize / 8 );
      rijndael.Key = keyGenerator.GetBytes( rijndael.KeySize / 8 );
      // decrypt
      using( var cryptoStream = new CryptoStream( fileStream, rijndael.CreateDecryptor(), CryptoStreamMode.Read ) )
      {
        // read data
      }
    }
