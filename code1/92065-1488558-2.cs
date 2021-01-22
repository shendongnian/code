    Invoice invoice = new Invoice("42-42-42", "Awesome Foo", 24, 42.42);
    invoice.Quantity = 42;
    Console.WriteLine("Part number : {0}", invoice.PartNumber);
    Console.WriteLine("Description : {0}", invoice.Description);
    Console.WriteLine("Price       : {0}", invoice.Price);
    Console.WriteLine("Quantity    : {0}", invoice.Quantity);
    Console.WriteLine("Total       : {0}", invoice.Total);
