    List<Customer> result = new List<Customer>();
    
    result = (from c in customer
              join o in order on c.Name equals o.CustomerName
              select new Customer
              {
                  Id = c.Id,
                  Name = c.Name,
                  OrderId = o.Id
              }).ToList();
    
    foreach (var item in result)
    {
        Console.WriteLine($"Id: {item.Id}, \t Name: {item.Name}, \t OrderId: {item.OrderId}");
    }
    
    Console.ReadLine();
