    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    public static class Helpers
    {
        public static Guid GetHash(string password)
        {
            return new Guid(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password.Trim())));
        }
    }
