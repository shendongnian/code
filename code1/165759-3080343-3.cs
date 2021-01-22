    FileHelperAsyncEngine engine = new FileHelperAsyncEngine(typeof(Customer));
    
    // Read
    engine.BeginReadFile("TestIn.txt");
    
    // The engine is IEnumerable 
    foreach(Customer cust in engine)
    {
       // your code here
       Console.WriteLine(cust.Name);
       // your condition >> add balance
    }
    
    engine.Close();
 
