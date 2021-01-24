    private List<Items> printItem = new List<Items>();
    class Items
    {
        public string printItemCode { get; set; }
        public string printPartNo { get; set; }
        public string printIssued { get; set; }
        public string printUOM { get; set; }
    }
    
    using (var rdr = cmd.ExecuteReader())
    {
        while (rdr.Read())
        {
            Items item = new Items()
            {
                printItemCode = rdr[0].ToString(),
                printPartNo = rdr[1].ToString(),
                printIssued = rdr[2].ToString(),
                printUOM = rdr[3].ToString(),
            };
            printItem.Add(item);
        }
    }
