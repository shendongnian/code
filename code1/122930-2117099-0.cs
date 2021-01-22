    public class ProductPriceComparer : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                if (x.Price > y.Price)
                    return 1;
                
                if (x.Price < y.Price)
                    return -1;
                return 0;
            }
        }
        public class ProductNameComparer : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
        public class Product
        {
            public Product(String name, Decimal price)
            {
                this.name = name;
                this.price = price;
            }
            private String name;
            public String Name
            {
                get { return name; }
                set { name = value; }
            }
            private Decimal price;
            public Decimal Price
            {
                get { return price; }
                set { price = value; }
            }
            public override string ToString()
            {
                return Name + " ($"+ Price.ToString() + ")";
            }
        }
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Product Z", 45.98m));
            products.Add(new Product("Product D", 12.80m));
            products.Add(new Product("Product A", 25.19m));
            products.Add(new Product("Product B", 65.00m));
            products.Add(new Product("Product P", 5.14m));
            Console.WriteLine("PRODUCTS SORTED BY PRICE");
            products.Sort(new ProductPriceComparer());
            foreach (Product p in products)
                Console.WriteLine(p.ToString());
            Console.WriteLine("\n--------------------------------\n");
            Console.WriteLine("PRODUCTS SORTED BY NAME");
            products.Sort(new ProductNameComparer());
            foreach (Product p in products)
                Console.WriteLine(p.ToString());
        }
