    public static string ByteArrayToString(byte[] ba)
    {
      StringBuilder hex = new StringBuilder(ba.Length * 2);
      foreach (byte b in ba)
        hex.AppendFormat("{0:X2} ", b);             // <-- I inserted a space in the format string
      return hex.ToString();
    }
