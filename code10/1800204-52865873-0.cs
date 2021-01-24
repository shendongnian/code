    class NewProductArgs: EventArgs
    {
        public IList<string> ReturnValues { get; } = new List<string>();
        public Product Product { get; set; }
    }
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Cart
    {
        public event EventHandler<NewProductArgs> ProductAddedEvent;
        public void Add(Product product)
        {
            var args = new NewProductArgs { Product = product };
            ProductAddedEvent?.Invoke(this, args);
            var retvals = args.ReturnValues; 
            foreach (var ret in retvals)
            {
                Console.WriteLine(ret);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();
            cart.ProductAddedEvent += DisplayAddedProduct;
            cart.ProductAddedEvent += AnotherEventHandler;
            cart.Add(new Product { Name = "Product-1", Price = 100.0m });
            cart.Add(new Product { Name = "Product-2", Price = 200.0m });
        }
        static void AnotherEventHandler(object sender, NewProductArgs args)
        {
            args.ReturnValues.Add($"Handler2: {args.Product.Name} {args.Product.Price}");
        }
        static void DisplayAddedProduct(object sender, NewProductArgs args)
        {
            args.ReturnValues.Add($"Handler1 : {args.Product.Name} {args.Product.Price}");
        }
    }
