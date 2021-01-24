    public static class Utilities
    {
        public static string encryptString(this string str)
        {
               System.Security.Cryptography.MD5CryptoServiceProvider x = new      System.Security.Cryptography.MD5CryptoServiceProvider();
               byte[] data = System.Text.Encoding.ASCII.GetBytes(str);
               data = x.ComputeHash(data);
     
               return System.Text.Encoding.ASCII.GetString(data);
         }
    }
