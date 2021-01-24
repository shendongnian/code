      using System.Security.Cryptography;
      public static string Get50RandomHexNybls()
      {
          var bytes = new byte[25];
          var rand = new RNGCryptoServiceProvider();
          rand.GetBytes(bytes);
          return BitConverter.ToString(bytes).Replace("-", string.Empty);
      }
