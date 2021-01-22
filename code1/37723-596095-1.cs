    Savepoint sp1 = new Savepoint();
    sp1.iOffset = 4;
    Savepoint sp2 = new Savepoint();
    Savepoint sp3 = null;
    
    Console.WriteLine("sp1: " + (sp1 ? "true" : "false")); // prints true
    Console.WriteLine("sp2: " + (sp2 ? "true" : "false")); // prints false
    Console.WriteLine("sp3: " + (sp3 ? "true" : "false")); // prints false
