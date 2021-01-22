    static byte[] HexToBin(string hex)
    {
       var result = new byte[hex.Length/2];
       for (int i = 0; i < hex.Length; i += 2)
       {
          result[i / 2] = byte.Parse(hex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
       }
       return result;
    }
