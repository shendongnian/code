    public class Product
    {
        private static int nextId = 0;
        public int Id { get; private set; }
        ...
        public Product()
        {
            Id = nextId++;
            Quantity = 0;
        }
    }
    Product product1 = new Product() { /*Id = 0, */ Name = "Buzz Cola" };
