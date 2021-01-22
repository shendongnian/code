            Department department1 = new Department
            {
                Id = 1,
                Name = "D1",
                Products = new List<Product> () { new Product { Id = 1, Name = "Item1" }, new Product { Id = 2, Name = "Item2" } }
            };
            Department department2 = new Department
            {
                Id = 2,
                Name = "D2",
                Products = new List<Product>() { new Product { Id = 2, Name = "Item2" }, new Product { Id = 3, Name = "Item3" } }
            };
            IEnumerable<Product> products = department1.Products.Intersect(department2.Products, new ProductComparer());
            foreach (var p in products)
            {
                Console.WriteLine(p.Name);
            }
