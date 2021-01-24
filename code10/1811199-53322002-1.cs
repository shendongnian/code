    namespace Test
    {
        class Product
        {
            static private List<Product> Products;
            private int id;
            private string name;
            private double currency;
            public Product(int id, string name, double currency)
            {
                this.id = id;
                this.name = name;
                this.currency = currency;
            }
            public static void AddProduct(Product product)
            {
                if (Products == null)
                {
                    Products = new List<Product>();
                }
                Products.Add(product);
            }
            public static void GetListOfProducts()
            {
                foreach (Product product in Products)
                {
                    Console.WriteLine(String.Format("id:{0} name:{1} currency:{2}", product.id, product.name, product.currency));
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Product p = new Product(1, "TID", 13.2);
                Product.AddProduct(p);
                Product.GetListOfProducts();
            }
        }
    }
