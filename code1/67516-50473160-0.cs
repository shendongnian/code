    public static string BuildSecureHexString(int hexCharacters)
    {
        var byteArray = new byte[(int)Math.Ceiling(hexCharacters / 2.0)];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(byteArray);
        }
        return String.Concat(Array.ConvertAll(byteArray, x => x.ToString("X2")));
    }
