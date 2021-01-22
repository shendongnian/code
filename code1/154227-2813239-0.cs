    // assuming ArrangList1 is List<string[]>
    var query = from a in ArrangList1
                from b in a
                select b;
    
    foreach (String s in query)
    {
        System.Console.Writeline(s);
    }
