    static void Main(string[] args)
    {
            //asign some demo data
            var tpd = new List<ThirdPartyData>();
            tpd.Add(new ThirdPartyData { ASIN = "mark: NsQf8", type = 0, Price = 7, IsPrime = 1, OutOfStock = 1 });
            tpd.Add(new ThirdPartyData { ASIN = "fD5tsQ ", type = 1, Price = 13, IsPrime = 0, OutOfStock = 0 });
            tpd.Add(new ThirdPartyData { ASIN = "notmark: tvQtsu", type = 1, Price = 14, IsPrime = 1, OutOfStock = 1 });
            //this tpd list should be converted string like bellow-
            //Converted String output should be like this- 'ASIN-NsQf8,type-0,Price-7,IsPrime-1,OutOfStock-1:ASIN-fD5tsQ,type-1,Price-13,IsPrime-0,OutOfStock-0:ASIN-tvQtsu,type-1,Price-14,IsPrime-1,OutOfStock-1'
            var individual = tpd.Select(t => $"ASIN-{ (t.ASIN.Split(new char[]{ ':' }).Length == 1 ? t.ASIN.Split(new char[] { ':' })[0].Trim() : t.ASIN.Split(new char[] { ':' })[1].Trim()) },type-{t.type},Price-{t.Price},IsPrime-{t.IsPrime},OutOfStock-{t.OutOfStock}").ToArray();
            var output = string.Join(",", individual);
            Console.WriteLine(output);
            Console.ReadLine();
    }
