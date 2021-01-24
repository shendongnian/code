    public class ProductBuilder
    {
        private string _productName;
        private decimal _price;
        private int _quantity;
        public ProductBuilder ProductName(string name)
        {
            _productName = name;
            return this;
        }
        public ProductBuilder Price(decimal price)
        {
            _price = price;
            return this;
        }
        public ProductBuilder Quantity(int quantity)
        {
            _quantity = quantity;
            return this;
        }
        public Product Create()
        {
            return new Product
            {
                Info = new ProductInfo { Name = _productName },
                Price = _price,
                Quantity = _price, 
            }
        }
    }
