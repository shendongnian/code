    static void Main(string[] args)
    {
        var salt = "MySalt";
        var password = "MyPassword";
        var saltedKey = CalculateHash(salt, password);
        Console.WriteLine(saltedKey);
        // MySalt$teGOpFi57nENIRifSW3m1RQndiU=
        var checkHash = CheckHash(saltedKey, password);
        Console.WriteLine(checkHash);
        // True
    }
    private static string CalculateHash(string saltOrSaltedKey, string password)
    {
        var salt =
            saltOrSaltedKey.Contains('$')
            ? saltOrSaltedKey.Substring(0, saltOrSaltedKey.IndexOf('$') + 1)
            : saltOrSaltedKey + '$';
        var newKey = Encoding.UTF8.GetBytes(salt + password);
        var sha1 = SHA1.Create();
        sha1.Initialize();
        var result = sha1.ComputeHash(newKey);
        // if you replace this base64 version with one of the encoding 
        //   classes this will become corrupt due to nulls and other 
        //   control character values in the byte[]
        var outval = salt + Convert.ToBase64String(result);
        return outval;
    }
    private static bool CheckHash(string saltedKey, string password)
    {
        var outval = CalculateHash(saltedKey, password);
        return outval == saltedKey;
    }
