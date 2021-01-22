    public static byte[] StringToByteArray(string hex) {
      return Enumerable.Range(0, hex.Length).
             Where(x => 0 == x % 2).
             Select(x => Convert.ToByte(hex.SubString(x,2), 16)).
             ToArray();
    }
