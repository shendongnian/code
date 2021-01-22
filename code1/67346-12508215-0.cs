    public void Linq53() 
    { 
        List<Product> products = GetProductList(); 
        List<Customer> customers = GetCustomerList(); 
      
        var productFirstChars = 
            from p in products 
            select p.ProductName[0]; 
        var customerFirstChars = 
            from c in customers 
            select c.CompanyName[0]; 
      
        var productOnlyFirstChars = productFirstChars.Except(customerFirstChars); 
      
        Console.WriteLine("First letters from Product names, but not from Customer names:"); 
        foreach (var ch in productOnlyFirstChars) 
        { 
            Console.WriteLine(ch); 
        } 
    }
