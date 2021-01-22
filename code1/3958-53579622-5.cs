    var products = new List<Product>
                {
                    new Product{ProductName = "product 1" ,Id = 1,},
                    new Product{ProductName = "product 2" ,Id = 2,},
                    new Product{ProductName = "product 2" ,Id = 4,},
                    new Product{ProductName = "product 2" ,Id = 4,},
                };
    var productList = products.Distinct(new ItemEqualityComparer<Product>(nameof(Product.Id))).ToList();
    var customers = new List<Customer>
                {
                    new Customer{CustomerName = "Customer 1" ,Id = 5,},
                    new Customer{CustomerName = "Customer 2" ,Id = 5,},
                    new Customer{CustomerName = "Customer 2" ,Id = 5,},
                    new Customer{CustomerName = "Customer 2" ,Id = 5,},
                };
    var customerList = customers.Distinct(new ItemEqualityComparer<Customer>(nameof(Customer.Id))).ToList();
