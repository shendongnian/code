    static string BytesToHex(byte[] bytes)
    {
       System.Text.StringBuilder sb = new StringBuilder();
       for (int i = 0; i < bytes.Length; i++)
       {
          sb.Append(bytes[i].ToString("x2"));
       }
       return sb.ToString();
    }
