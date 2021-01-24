    class ThirdPartyData
    {
        public string ASIN { get; set; }
        public int type { get; set; }
        public int Price { get; set; }
        public int IsPrime { get; set; }
        public int OutOfStock { get; set; }
        public string ToExport()
        {
            return $"ASIN-{ASIN},type-{type},..."
        }
    }
