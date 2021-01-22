    private const int SaltSize = 8;
    public static void Encrypt( FileInfo targetFile, string password )
    {
      var keyGenerator = new Rfc2898DeriveBytes( password, SaltSize );
      var rijndael = Rijndael.Create();
      // BlockSize, KeySize in bit --> divide by 8
      rijndael.IV = keyGenerator.GetBytes( rijndael.BlockSize / 8 );
      rijndael.Key = keyGenerator.GetBytes( rijndael.KeySize / 8 );
      using( var fileStream = targetFile.Create() )
      {
        // write random salt
        fileStream.Write( keyGenerator.Salt, 0, SaltSize );
        using( var cryptoStream = new CryptoStream( fileStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write ) )
        {
          // write data
        }
      }
    }
