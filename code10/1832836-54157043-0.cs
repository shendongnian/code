    [TestClass]
    public class ProductTests
    {
        Product product;
        [TestInitialize]
        public void Setup()
        {
            product = new Product { Info = new ProductInfo() };
        }
        [TestMethod]
        public void ProductInfoTitleTest()
        {
            decimal price = 120;
            string productName = "Product1";
            product.Info.Name = productName;
            product.Price = price;
            Assert.AreEqual($"{productName}-{price} USD", product.Info.Title, "Both should be equal");
        }
        [TestMethod]
        public void ProductTotalPriceTest()
        {
            product.Price = 100;
            product.Quantity = 2;
            Assert.AreEqual(200, product.TotalPrice, "It should be 200");
        }
    }
