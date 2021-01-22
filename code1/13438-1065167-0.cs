    static byte[] HexToBinary(string s) {
      byte[] b = new byte[s.Length / 2];
      for (int i = 0; i < b.Length; i++)
        b[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
      return b;
    }
    static string BinaryToHex(byte[] b) {
      StringBuilder sb = new StringBuilder(b.Length * 2);
      for (int i = 0; i < b.Length; i++)
        sb.Append(Convert.ToString(256 + b[i], 16).Substring(1, 2));
      return sb.ToString();
    }
