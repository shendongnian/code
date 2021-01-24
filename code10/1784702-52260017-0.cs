    for (int i = 0; i < input; i++)
    {
        Console.WriteLine("1-Customer Name:\n2-Customer Address:\n3-Customer Telno.:\n4-Customer Email:\n5-:Branch Name:\n");
        var customer = new Customer
        {
            CustomerName = Console.ReadLine()
        };
        //Search existing customer
        var existingCustomer = Customers.FirstOrDefault(c => c.CustomerName == customer.CustomerName);
        if (existingCustomer != null)
        { //existing customer encountered
            customers.Add(existingCustomer);
        }
        else
        {
            customer.CustomerID = Guid.NewGuid(); // generate new ID
            customer.CustomerAddress = Console.ReadLine();
            customer.CustomerTelNo = Console.ReadLine();
            customer.CustomerEmail = Console.ReadLine();
            customers.Add(customer);
            Customers.Add(customer); // add to global list
        }
    }
