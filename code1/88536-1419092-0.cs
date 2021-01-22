    using System.Security.Cryptography
    public static string HashPassword(string unhashedPassword)
    {
        return BitConverter.ToString(new SHA512CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(unhashedPassword))).Replace("-", String.Empty).ToUpper();
    }
