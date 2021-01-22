    var engine = new FileHelperAsyncEngine<Customer>();
    
    // Read
    using(engine.BeginReadFile("TestIn.txt"))
    {
       // The engine is IEnumerable 
       foreach(Customer cust in engine)
       {
          // your code here
          Console.WriteLine(cust.Name);
          // your condition >> add balance
       }
    }
