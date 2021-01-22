    GetCustomers((list, exception) => { 
        Console.WriteLine("Encountered error processing the following customers");
        foreach(var customer in list) Console.WriteLine(customer.Name);
        Console.WriteLine(exception.Message);
    }); 
