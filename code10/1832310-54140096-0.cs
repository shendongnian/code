    class EODSales
    {
        public string Sales { get; set; }
        public int TC { get; set; }
        public decimal Amount { get; set; }
    }
    class EODBO
    {
        public string Sales { get; set; }
        public List<EODSales> Values { get; set; }
    }
    .
    .
    .
    .
    List<EODSales> EODSalesList = new List<EODSales>();
    List<EODBO> eodboList = new List<EODBO>();
    .
    .
    .
    //Inside a method - 
    EODSales sales = new EODSales();
    sales.Sales = "Prev";
    sales.TC = 5;
    sales.Amount = 500;
    EODSalesList.Add(sales);
    List<EODSales> localEODSalesList = new List<EODSales>();
    localEODSalesList.Add(sales);
    EODBO obj = new EODBO();
    obj.Sales = "Baking Order";
    obj.Values = localEODSalesList;
    eodboList.Add(obj);
    //Inside another method 
    EODSales sales = new EODSales();
    sales.Sales = "Prev";
    sales.TC = 10;
    sales.Amount = 1000;
    EODSalesList.Add(sales);
    List<EODSales> localEODSalesList = new List<EODSales>();
    localEODSalesList.Add(sales);
    EODBO obj = new EODBO();
    obj.Sales = "Baking Order";
    obj.Values = localEODSalesList;
    eodboList.Add(obj);
