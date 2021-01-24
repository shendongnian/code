        public class Product
        {
            public string ProductName { get; private set; }
            public string Price { get; private set; }
            public string Quantity { get; private set; }
    
            public override string ToString()
            {
                return $"Product Name: {this.ProductName} Price: {this.Price} Quantity: {this.Quantity}";
            }
    
        }
