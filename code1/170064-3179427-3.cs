    public static byte[] FromHexString(this string str)
    {
      //null check a good idea
      int NumberChars = str.Length;
      byte[] bytes = new byte[NumberChars / 2];
      for (int i = 0; i < NumberChars; i += 2)
        bytes[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
      return bytes;
    }
