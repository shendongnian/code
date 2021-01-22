    public class TestProduct
    {
        public int ManId { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Shipper { get; set; }
        public string Distributor { get; set; }
    }
    [TestMethod]
    public void TestSourceTable()
    {
        // Set up a test list
        var list = new List<TestProduct>();
        for (int i=0;i<5;i++)
        {
            var p = new TestProduct
                {
                    Distributor = "D" + i,
                    ManId = i,
                    ProductionDate = DateTime.Now,
                    ProductName = "P" + i,
                    Shipper = "S" + i
                };
            list.Add(p);
        }
        
        // Get an existing product
        var existingProduct = list[4];
        // Get an unknown product
        var unknownProduct = new TestProduct()
            {
                ManId = -1,
                Distributor = "",
                ProductionDate = DateTime.Now.AddDays(-1),
                ProductName = "",
                Shipper = ""
            };
         // product found
         Assert.True(list.Any(p => p == existingProduct));
         // product not found
         Assert.False(list.Any(p => p == unknownProduct));
    }
