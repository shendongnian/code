     // C# to convert a string to a byte array.
     public static byte[] StrToByteArray(string str)
     {
         System.Text.ASCIIEncoding  encoding=new System.Text.ASCIIEncoding();
         return encoding.GetBytes(str);
     }
