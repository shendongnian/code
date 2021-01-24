    public byte[] GetDelphiShortString(string str)
    {
      var bytes = new byte[256];
      bytes[0] = (byte)Encoding.Default.GetBytes(str, 0, str.Length, bytes, 1);
      return bytes;
    }
