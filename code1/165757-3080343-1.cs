    FileHelperAsyncEngine engine = new FileHelperAsyncEngine(typeof(Customer));
    
    // Read
    engine.BeginReadFile("TestIn.txt");
    
    // The engine is IEnumerable 
    foreach(Customer cust in engine)
    {
       // your code here
       Console.WriteLine(cust.Name);
    }
    
    engine.Close();
    
    // Write
    engine.BeginWriteFile("TestOut.txt");
    
    foreach(Customer cust in arrayCustomers)
    {
       engine.WriteNext(cust);
    }
    
    engine.Close();
