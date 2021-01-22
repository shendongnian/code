    Since C# 3.0 (November 19th 2007), we can use [auto-implemented properties][5] (this is merely [syntactic sugar][6]).
    And
        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
    becomes
        public int ProductID { get; set; }
