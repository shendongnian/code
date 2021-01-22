    using System.Security.Cryptography;
    /// <summary>
    /// Hash the given string with sha256
    /// </summary>
    /// <param name="password">the string to hash</param> 
    /// <returns>The hex representation of the hash</returns>
    static string sha256(string password)
    {
        SHA256Managed crypt = new SHA256Managed();
        string hash = String.Empty;
        byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
        foreach (byte bit in crypto)
        {
            hash += bit.ToString("x2");
        }
        return hash;
    }
 
