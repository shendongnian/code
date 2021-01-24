    public static string SHA256HashToBaseMessage(string payload, eBase baseToConvert) {
      //DONE: public method values' validation 
      if (null == payload)
        throw new ArgumentNullException(nameof(payload));
      int padLength =
        (baseToConvert == eBase.BINARY) ? 8 : // 8 for binary
        (baseToConvert == eBase.HEXA) ? 2 :   // 2 for hexadecimal
        3;                                    // 3 for decimal and octal
      StringBuilder sb = new StringBuilder();
      using (SHA256 sHA256 = SHA256.Create("SHA256")) {
        byte[] hash = sHA256.ComputeHash(Encoding.UTF8.GetBytes(payload));
        for (int i = 0; i < hash.Length; i++) 
          sb.Append(Convert.ToString(hash[i], (int)baseToConvert).PadLeft(padLength, '0'));
      }
      return sb.ToString();
    }
