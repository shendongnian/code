    private static void Main()
    {
        //asign some demo data
        var tpd = new List<ThirdPartyData>
        {
            new ThirdPartyData {ASIN = "mark: NsQf8", type = 0, Price = 7, IsPrime = 1, OutOfStock = 1},
            new ThirdPartyData {ASIN = "fD5tsQ ", type = 1, Price = 13, IsPrime = 0, OutOfStock = 0},
            new ThirdPartyData {ASIN = "notmark: tvQtsu", type = 1, Price = 14, IsPrime = 1, OutOfStock = 1}
        };
        var output = string.Join(":", tpd.Select(TpdToString));
        Console.WriteLine(output);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
