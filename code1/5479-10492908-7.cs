    // Construct a new context
    var context = new Context(ConfigurationManager.ConnectionStrings["VfpData"].ConnectionString);
    // Write to MyTable.dbf
    var my = new MyTable
    {
        ID = 1,
        Field1 = 10,
        Field2 = "foo",
        Field3 = "bar"
    }
    context.MyTables.Insert(my);
    
    // Read from MyTable.dbf
    Console.WriteLine("Count:  " + context.MyTables.Count());
    foreach (var o in context.MyTables)
    {
        Console.WriteLine(o.Field2 + " " + o.Field3);
    }
