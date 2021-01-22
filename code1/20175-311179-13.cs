    public static string ByteArrayToString(byte[] ba)
    {
      string hex = BitConverter.ToString(ba);
      return hex.Replace("-","");
    }
