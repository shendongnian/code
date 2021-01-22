    struct ProductPrimaryKey
    {
        public string KeySerial;
        public string OtherDiscriminator;
        public ProductPrimaryKey(string keySerial, string otherDiscriminator)
        {
            KeySerial = keySerial;
            OtherDiscriminator = otherDiscriminator;
        }
    }
    class Product
    {
        public string KeySerial { get; set; }
        public string OtherDiscriminator { get; set; }
        public int MoreData { get; set; }
    }
    class DataLayer
    {
        public Dictionary<ProductPrimaryKey, Product> DataSet 
            = new Dictionary<ProductPrimaryKey, Product>();
        public Product GetProduct(string keySerial, string otherDiscriminator)
        {
            return DataSet[new ProductPrimaryKey(keySerial, otherDiscriminator)];
        }
    }
