    private static readonly System.Security.Cryptography.RNGCryptoServiceProvider _secureRng;
    public static double NextSecureDouble()
    {
      var bytes = new byte[8];
      _secureRng.GetBytes(bytes);
      var v = BitConverter.ToUInt64(bytes, 0);
      // We only use the 53-bits of integer precision available in a IEEE 754 64-bit double.
      // The result is a fraction, 
      // r = (0, 9007199254740991) / 9007199254740992 where 0 <= r && r < 1.
      v &= ((1UL << 53) - 1);
      var r = (double)v / (double)(1UL << 53);
      return r;
    }
