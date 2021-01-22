    private static IEnumerable<IDataRecord> GetResults(this SqlCommand command) {
        using (var myTicket = new MyTicket())
        using (var reader = command.ExecuteReader()) {
            while (reader.Read()) {
                yield return reader;
            }
        }
        // the two resources in the using blocks above will be
        // disposed when the foreach loop below exits
    }
    
    ...
    foreach (var record in myCommand.GetResults()) {
    
        Console.WriteLine(record.GetString(0));
    
    }
    
    // when the foreach loop above completes, the compiler-generated
    // iterator is disposed, allowing the using blocks inside the
    // above method to clean up the reader/myTicket objects
