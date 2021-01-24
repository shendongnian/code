    var currentValues = 
    MyTable.GetValues()
           .ToList()        // Gets the values from the db and makes them IEnumerable
           .Select(itm => new {
                                  Status = DetermineStatus( … ), // "Red" | "Yellow" ...
                                  itm
                              }
                   )
           .ToList();
    ...
    private string DetermineStatus(...variables here....);
