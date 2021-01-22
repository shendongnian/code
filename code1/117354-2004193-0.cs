    private IEnumerable<IDataRecord> ExecuteReader(Command command) {
        using (var reader = command.ExecuteReader()) {
            while (reader.Read()) {
                yield return reader;
            }
            // dispose whatever else you want here
        }
    }
    
    ...
    foreach (var record in ExecuteReader(myCommand)) {
    
        Console.WriteLine(record.GetString(0));
    
    }   // this is where the using block above is exited
