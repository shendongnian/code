    public void Linq95()
    {
        List<Customer> customers = GetCustomerList();
        List<Product> products = GetProductList();
     
        var customerNames =
            from c in customers
            select c.CompanyName;
        var productNames =
            from p in products
            select p.ProductName;
     
        var allNames = customerNames.Concat(productNames);
     
        Console.WriteLine("Customer and product names:");
        foreach (var n in allNames)
        {
            Console.WriteLine(n);
        }
    }
