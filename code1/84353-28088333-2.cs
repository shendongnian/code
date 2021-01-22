    private string RandomName
    {
        get
        {
            return new string(
                Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 13)
                    .Select(s =>
                    {
                        var cryptoResult = new byte[4];
                        using (var cryptoProvider = new RNGCryptoServiceProvider())
                            cryptoProvider.GetBytes(cryptoResult);
                        return s[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(s.Length)];
                    })
                    .ToArray());
        }
    }
