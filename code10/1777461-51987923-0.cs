    class Program
        {
            static void Main(string[] args)
            {
    
                //asign some demo data
                var tpd = new List<ThirdPartyData>();
    
                tpd.Add(new ThirdPartyData { ASIN = "mark: NsQf8", type = 0, Price = 7, IsPrime = 1, OutOfStock = 1 });
                tpd.Add(new ThirdPartyData { ASIN = "fD5tsQ ", type = 1, Price = 13, IsPrime = 0, OutOfStock = 0 });
                tpd.Add(new ThirdPartyData { ASIN = "notmark: tvQtsu", type = 1, Price = 14, IsPrime = 1, OutOfStock = 1 });
    
                //this tpd list should be converted string like bellow-
    
                //Converted String output should be like this- 'ASIN-NsQf8,type-0,Price-7,IsPrime-1,OutOfStock-1:ASIN-fD5tsQ,type-1,Price-13,IsPrime-0,OutOfStock-0:ASIN-tvQtsu,type-1,Price-14,IsPrime-1,OutOfStock-1'
    
                var strings = new List<string>();
                tpd.ForEach(item => strings.Add(item.ToString()));
                string output =string.Join(",", strings);
            }
    
        }
    
        class ThirdPartyData
        {
            public string ASIN { get; set; }
            public int type { get; set; }
            public int Price { get; set; }
            public int IsPrime { get; set; }
            public int OutOfStock { get; set; }
    
            public override string ToString()
            {
                string[] asin = ASIN.Split(':');
                string asinString = string.Empty;
                if (asin.Length >= 1)
                {
                    asinString = asin[1];
                }
                return $"ASIN-{asinString},type-{type},Price-{Price},IsPrime-{IsPrime},OutOfStock-{OutOfStock}";
            }
