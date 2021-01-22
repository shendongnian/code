    private List<string> Generate(int count)
        {
            var list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list.Add( new string(
                Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 13)
                    .Select(s =>
                    {
                        var cryptoResult = new byte[4];
                        new RNGCryptoServiceProvider().GetBytes(cryptoResult);
                        return s[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(s.Length)];
                    })
                    .ToArray())); 
            }
            return list;
        }
