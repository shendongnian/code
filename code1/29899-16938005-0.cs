    public static byte[] StrToByteArray(string str)
    {
      System.Text.UTF8Encoding  encoding=new System.Text.UTF8Encoding();
      return encoding.GetBytes(str);
   }
