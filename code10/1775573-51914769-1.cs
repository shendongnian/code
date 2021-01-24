    public static string MakeHash(string value)
            {
                return Convert.ToBase64String(
                    System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value))
                    );
            }
    
    
            public static bool CompareHash(string plainString, string hashString)
            {
                if (MakeHash(plainString) == hashString)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
