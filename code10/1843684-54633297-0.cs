    private static int ParseXInt(string x, int i, int n) =>
        int.Parse(x.Substring(i, n),
                  System.Globalization.NumberStyles.HexNumber);
    public static string Decrypt(string s) =>
        new string(s.Split('-')
                    .Select(x => (char)(ParseXInt(x, 0, 1) ^
                                        ParseXInt(x, 1, 2)))
                    .ToArray());
