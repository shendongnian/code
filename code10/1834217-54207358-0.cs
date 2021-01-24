    using System.Security.Cryptography;
    
    static class Extentions
    {
    
        public static string Sha256(this string input)
        {
            using (SHA256 shA256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                return Convert.ToBase64String(((HashAlgorithm)shA256).ComputeHash(bytes));
            }
        }
    }
    
    
    void Main()
    {
        Console.WriteLine( "secret-as-guid".Sha256());
    }
