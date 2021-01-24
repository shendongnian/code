    var engine = new FileHelperAsyncEngine<Customer>();
    
    // Read
    using(engine.BeginReadFile("Input.txt"))
    {
        // The engine is IEnumerable
        foreach(Customer cust in engine)
        {
            // your code here
            Console.WriteLine(cust.Name);
        }
    }
    
    
    // Write     
    using(engine.BeginWriteFile("TestOut.txt"))
    {
        var arrayCustomers = GetSomeMoreCustomers(); // a batch at a time
        if (arrayCustomers.Count() > 0)
        { 
            foreach(Customer cust in arrayCustomers)
            {
                engine.WriteNext(cust);
            }
        }
    }
