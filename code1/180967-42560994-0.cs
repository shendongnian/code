    var aggregatException = Type.GetType("System.AggregateException");
    
    if (aggregatException != null) // .Net 4 or greater
    {
        throw ((Exception)Activator.CreateInstance(aggregatException, ps.Streams.Error.Select(err => err.Exception)));
    }
    
    // Else all other non .Net 4 or less versions
    throw ps.Streams.Error.FirstOrDefault()?.Exception 
          ?? new Exception("Powershell Exception Encountered."); // Sanity check operation, should not hit.
 
