    var tables = dbServer.Tables                         // step 1
        .Where(table => !table.IsSet)                    // step 2
        .SelectMany(table => table.References)           // step 3
        .Where(refer => refer.PrimaryTable == "myTable") // step 4
        .ToList();                                       // step 5
