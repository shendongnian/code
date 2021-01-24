    public class Service
        {
            public List<Product> Order { get; set; }
            public void addToOrderFromPicture(string product, string qty, string _price)
            {
                Order.Add(product);
            }
        }
